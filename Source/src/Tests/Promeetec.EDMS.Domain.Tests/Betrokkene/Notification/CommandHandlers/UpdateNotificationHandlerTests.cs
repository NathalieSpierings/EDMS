using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Handlers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Notification.CommandHandlers;


[TestFixture]
public class UpdateNotificationHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private INotificatieRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new NotificatieRepository(_context);
    }


    [Test]
    public async Task Should_update_memo_and_add_event()
    {
        var cmd = Fixture.Create<CreateNotificatie>();

        var noti = new Notificatie(cmd);
        _context.Notificaties.Add(noti);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateNotificatie>()
            .With(x => x.Id, noti.Id)
            .With(x => x.OrganisatieId, noti.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .With(x => x.NotificatieStatus, NotificatieStatus.Gelezen)
            .Create();


        var sut = new UpdateNotificatieHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Notificaties.FirstOrDefaultAsync(x => x.Id == noti.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == noti.Id);


        Assert.AreEqual(command.NotificatieStatus, dbEntity.NotificatieStatus);
        Assert.NotNull(@event);
    }
}
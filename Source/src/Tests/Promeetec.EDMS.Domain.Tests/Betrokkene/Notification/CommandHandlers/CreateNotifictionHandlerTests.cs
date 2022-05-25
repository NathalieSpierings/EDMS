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
public class CreateNotificationHandlerTests : TestFixtureBase
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
    public async Task Should_create_new_notification_and_add_event()
    {
        var command = Fixture.Create<CreateNotificatie>();

        var sut = new CreateNotificatieHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Notificaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
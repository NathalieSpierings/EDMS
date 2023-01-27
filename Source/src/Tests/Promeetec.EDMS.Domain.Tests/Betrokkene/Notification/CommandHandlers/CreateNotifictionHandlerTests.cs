using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Notification.CommandHandlers;


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
    public async Task Should_create_new_notification()
    {
        var command = Fixture.Create<CreateNotificatie>();

        var sut = new CreateNotificatieHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Notificaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.Null(@event);
    }
}
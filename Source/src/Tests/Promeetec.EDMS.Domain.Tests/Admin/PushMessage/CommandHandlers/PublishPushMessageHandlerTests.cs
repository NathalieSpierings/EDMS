using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.PushMessage.CommandHandlers;


[TestFixture]
public class PublishPushMessageHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private ILandRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new LandRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_reinstate_land_and_add_event()
    {
        var cmd = Fixture.Build<CreateLand>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var land = new Models.Betrokkene.Land.Land(cmd);
        _context.Landen.Add(land);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ReinstateLand>()
            .With(x => x.Id, land.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ReinstateLandHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == land.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == land.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Actief, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
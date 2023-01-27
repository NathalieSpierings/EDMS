using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Behandelplan.CommandHandlers;


[TestFixture]
public class StopBehandeltrajectHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGliBehandelplanRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new GliBehandelplanRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_stop_behandeltraject_and_add_event()
    {
        var cmd = Fixture.Build<StartBehandeltraject>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var behandelplan = new GliBehandelplan(cmd);
        _context.GliBehandelplannen.Add(behandelplan);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<StopBehandeltraject>()
            .With(x => x.Id, behandelplan.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();
        
        var sut = new StopBehandeltrajectHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.GliBehandelplannen.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
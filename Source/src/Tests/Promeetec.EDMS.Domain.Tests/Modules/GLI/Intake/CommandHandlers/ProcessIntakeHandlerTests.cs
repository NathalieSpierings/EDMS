using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Intake.CommandHandlers;


[TestFixture]
public class ProcessIntakeHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGliIntakeRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new GliIntakeRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_reinstate_intake_and_add_event()
    {
        var cmd = Fixture.Build<CreateIntake>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var intake = new GliIntake(cmd);
        _context.GliIntakes.Add(intake);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ProcessIntake>()
            .With(x => x.Id, intake.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ProcessIntakeHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.GliIntakes.FirstOrDefaultAsync(x => x.Id == intake.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);
        
        Assert.NotNull(dbEntity);
        Assert.AreEqual(true, dbEntity?.Verwerkt);
        Assert.NotNull(@event);
    }
}
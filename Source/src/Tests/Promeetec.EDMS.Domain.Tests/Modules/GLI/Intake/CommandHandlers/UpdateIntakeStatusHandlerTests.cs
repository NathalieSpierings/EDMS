using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Intake.CommandHandlers;


[TestFixture]
public class UpdateIntakeStatusHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGliIntakeRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new GliIntakeRepository(_context);
    }


    [Test]
    public async Task Should_suspend_intake_and_add_event()
    {
        var cmd = Fixture.Build<CreateIntake>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var intake = new GliIntake(cmd);
        _context.GliIntakes.Add(intake);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateIntakeStatus>()
            .With(x => x.Id, intake.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new UpdateIntakeStatusHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.GliIntakes.FirstOrDefaultAsync(x => x.Id == intake.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.GliStatus, dbEntity?.GliStatus);
    }
}
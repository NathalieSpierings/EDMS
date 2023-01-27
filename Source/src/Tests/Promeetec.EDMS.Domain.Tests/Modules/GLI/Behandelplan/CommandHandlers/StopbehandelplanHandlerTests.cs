using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Behandelplan.CommandHandlers;


[TestFixture]
public class StopbehandelplanHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGliBehandelplanRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new GliBehandelplanRepository(_context);
    }


    [Test]
    public async Task Should_stop_behandelplan()
    {
        var cmd = Fixture.Build<StartBehandeltraject>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var behandelplan = new GliBehandelplan(cmd);
        _context.GliBehandelplannen.Add(behandelplan);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<StopBehandelplan>()
            .With(x => x.Id, behandelplan.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new StopbehandelplanHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.GliBehandelplannen.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
    }
}
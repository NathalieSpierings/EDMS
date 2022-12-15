using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Behandelplan.CommandHandlers;


[TestFixture]
public class WijzigBehandelplanStatusHandlerTests : TestFixtureBase
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
    public async Task Should_update_behandelplan_status()
    {
        var cmd = Fixture.Build<StartBehandeltraject>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var behandelplan = new GliBehandelplan(cmd);
        _context.GliBehandelplannen.Add(behandelplan);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateBehandelplanStatus>()
            .With(x => x.Id, behandelplan.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new WijzigBehandelplanStatusHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.GliBehandelplannen.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
    }
}
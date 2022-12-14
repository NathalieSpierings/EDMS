using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Declaratie.Aanleverbericht.CommandHandlers;


[TestFixture]
public class CloseAanleverberichtHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IAanleverberichtRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new AanleverberichtRepository(_context);
    }

    [Test]
    public void Should_throw_data_exception_when_aanleverbericht_not_found()
    {
        var sut = new CloseAanleverberichtHandler(_repository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<CloseAanleverbericht>()));
    }

    [Test]
    public async Task Should_close_aanleveringbericht()
    {
        var cmd = Fixture.Build<CreateAanleverbericht>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var aanlevering = new Models.Modules.Declaratie.Aanleverbericht.Aanleverbericht(cmd, 0);
        _context.Aanleverberichten.Add(aanlevering);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<CloseAanleverbericht>()
            .With(x => x.Id, aanlevering.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new CloseAanleverberichtHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Aanleverberichten.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(AanleverberichtStatus.Gesloten, dbEntity?.AanleverberichtStatus);
    }
}
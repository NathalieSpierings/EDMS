using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers;
using Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekerde.CommandHandlers;


[TestFixture]
public class AssingVerzekerdeHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerzekerdeRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new VerzekerdeRepository(_context);
    }

    [Test]
    public async Task Should_asign_verzekerde()
    {
        var cmd = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                .Without(x => x.Verzekerden)
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var verzekerde = new Models.Betrokkene.Verzekerde.Verzekerde(cmd);
        _context.Verzekerden.Add(verzekerde);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<AssingVerzekerde>()
            .With(x => x.Id, verzekerde.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();



        var sut = new AssingVerzekerdeHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Verzekerden.FirstOrDefaultAsync(x => x.Id == verzekerde.Id);

        Assert.NotNull(dbEntity);
    }
}
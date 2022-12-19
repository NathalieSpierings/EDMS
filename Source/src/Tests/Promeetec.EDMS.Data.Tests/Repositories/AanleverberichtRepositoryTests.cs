using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Data.Tests.Repositories;

[TestFixture]
public class AanleverberichtRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IAanleverberichtRepository _sut;
    private string ConnectionString = "Server=.;Database=Promeetec.EDMS.DOTCore;Trusted_Connection=True; Encrypt=False;MultipleActiveResultSets=true";

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(new DbContextOptionsBuilder<EDMSDbContext>().UseSqlServer(ConnectionString).Options);
        _sut = new AanleverberichtRepository(_context);
    }

    [Test]
    public async Task Should_get_aanleverbericht()
    {
        var cmdAanlevering = Fixture.Build<CreateAanlevering>()
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();
        
        var aanlevering = new Aanlevering(cmdAanlevering);
        _context.Aanleveringen.Add(aanlevering);
        await _context.SaveChangesAsync();

        var cmdBericht = Fixture.Build<CreateAanleverbericht>()
            .With(x => x.AanleveringId, aanlevering.Id)
            .With(x => x.OrganisatieId, aanlevering.OrganisatieId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var aanleverbericht = new Aanleverbericht(cmdBericht,1);
        _context.Aanleverberichten.Add(aanleverbericht);
        await _context.SaveChangesAsync();

        var actual = _sut.GetAanleverbericht(aanleverbericht.Id, aanleverbericht.AanleveringId);
        Assert.NotNull(actual);
    }
}

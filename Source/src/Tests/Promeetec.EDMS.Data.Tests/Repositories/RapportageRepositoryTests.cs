using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Data.Tests.Repositories;

[TestFixture]
public class RapportageRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IRapportageRepository _sut;

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _sut = new RapportageRepository(_context);
    }

    [Test]
    public async Task Should_get_rapportage_by_id()
    {
        var cmdOrg = Fixture.Create<CreateOrganisatie>();
        var organisatie = new Organisatie(cmdOrg);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        var cmdMed = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var eigenaar = new Medewerker(cmdMed);
        _context.Medewerkers.Add(eigenaar);
        await _context.SaveChangesAsync();

        var cmdRapportage = Fixture.Build<CreateRapportage>()
            .With(x => x.OrganisatieId, organisatie.Id)
            .With(x => x.EigenaarId, eigenaar.Id)
            .Create();
        var rapportage = new Rapportage(cmdRapportage);
        _context.Rapportages.Add(rapportage);
        await _context.SaveChangesAsync();
        
        var actual = await _sut.GetRapportageByIdsAsync(rapportage.Id, rapportage.OrganisatieId);
        Assert.NotNull(actual);
    }

    [Test]
    public async Task Should_get_rapportage_by_list_of_ids()
    {
        var cmdOrg = Fixture.Create<CreateOrganisatie>();
        var organisatie = new Organisatie(cmdOrg);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        var cmdMed = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var eigenaar = new Medewerker(cmdMed);
        _context.Medewerkers.Add(eigenaar);
        await _context.SaveChangesAsync();

        var cmdRapportage1 = Fixture.Build<CreateRapportage>()
            .With(x => x.OrganisatieId, organisatie.Id)
            .With(x => x.EigenaarId, eigenaar.Id)
            .Create();
        var rapportage1 = new Rapportage(cmdRapportage1);

        var cmdRapportage2 = Fixture.Build<CreateRapportage>()
            .With(x => x.OrganisatieId, organisatie.Id)
            .With(x => x.EigenaarId, eigenaar.Id)
            .Create();
        var rapportage2 = new Rapportage(cmdRapportage2);

        _context.Rapportages.Add(rapportage1);
        _context.Rapportages.Add(rapportage2);
        await _context.SaveChangesAsync();

        var actual = await _sut.GetRapportagesByIdsAsync(new List<Guid> { rapportage1.Id, rapportage2.Id });
        Assert.NotNull(actual);
    }
}

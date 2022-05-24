using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators.Handlers;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators.Rules;
using Promeetec.EDMS.Domain.Models.Cov;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.ION;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Organisatie.Rules;

[TestFixture]
public class IsOrganisatieNummerUniqueTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IOrganisatieRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new OrganisatieRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_return_true_when_nummer_is_unique()
    {
        var cmd = new CreateOrganisatie
        {
            Id = Guid.NewGuid(),
            Nummer = "1234",
            Naam = "Test org 1",
            TelefoonZakelijk = "1234567897",
            TelefoonPrive = "7894561236",
            Email = "email@test.com",
            Website = "http://www.test.com",
            AgbCodeOnderneming = "12345678",
            Zorggroep = false,
            Logo = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            Settings = new OrganisatieSettings
            {
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            VoorraadId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();


        var sut = new IsOrganisatieNummerUniqueHandler(_repository);
        var actual = await sut.Handle(new IsOrganisatieNummerUnique
        {
            Nummer = "Blah blah"
        });

        Assert.IsTrue(actual);
    }

    [Test]
    public async Task Should_return_true_when_nummer_is_unique_for_existing_organisatie()
    {
        var cmd = new CreateOrganisatie
        {
            Id = Guid.NewGuid(),
            Nummer = "1234",
            Naam = "Test org 1",
            TelefoonZakelijk = "1234567897",
            TelefoonPrive = "7894561236",
            Email = "email@test.com",
            Website = "http://www.test.com",
            AgbCodeOnderneming = "12345678",
            Zorggroep = false,
            Logo = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            Settings = new OrganisatieSettings
            {
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            VoorraadId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);

        var cmd1 = cmd;
        cmd1.Id = Guid.NewGuid();
        cmd1.Nummer = "5678";
        cmd1.Naam = "Test org 2";
        var organisatie1 = new Models.Betrokkene.Organisatie.Organisatie(cmd1);


        _context.Organisaties.Add(organisatie);
        _context.Organisaties.Add(organisatie1);
        await _context.SaveChangesAsync();


        var sut = new IsOrganisatieNummerUniqueHandler(_repository);
        var actual = await sut.Handle(new IsOrganisatieNummerUnique { Nummer = "9999", Id = Guid.NewGuid() });

        Assert.IsTrue(actual);
    }

    [Test]
    public async Task Should_return_false_when_nummer_is_not_unique()
    {
        var cmd = new CreateOrganisatie
        {
            Id = Guid.NewGuid(),
            Nummer = "1234",
            Naam = "Test org 1",
            TelefoonZakelijk = "1234567897",
            TelefoonPrive = "7894561236",
            Email = "email@test.com",
            Website = "http://www.test.com",
            AgbCodeOnderneming = "12345678",
            Zorggroep = false,
            Logo = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            Settings = new OrganisatieSettings
            {
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            VoorraadId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);

        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();


        var sut = new IsOrganisatieNummerUniqueHandler(_repository);
        var actual = await sut.Handle(new IsOrganisatieNummerUnique { Nummer = "1234", Id = Guid.NewGuid() });

        Assert.IsFalse(actual);
    }

    [Test]
    public async Task Should_return_false_when_nummer_is_not_unique_for_existing_organisatie()
    {
        var cmd = new CreateOrganisatie
        {
            Id = Guid.NewGuid(),
            Nummer = "1234",
            Naam = "Test org 1",
            TelefoonZakelijk = "1234567897",
            TelefoonPrive = "7894561236",
            Email = "email@test.com",
            Website = "http://www.test.com",
            AgbCodeOnderneming = "12345678",
            Zorggroep = false,
            Logo = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            Settings = new OrganisatieSettings
            {
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            VoorraadId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);

        var cmd1 = cmd;
        cmd1.Id = Guid.NewGuid();
        cmd1.Nummer = "5678";
        cmd1.Naam = "Test org 2";
        var organisatie1 = new Models.Betrokkene.Organisatie.Organisatie(cmd1);


        _context.Organisaties.Add(organisatie);
        _context.Organisaties.Add(organisatie1);
        await _context.SaveChangesAsync();

        var userId = Guid.NewGuid();
        var sut = new IsOrganisatieNummerUniqueHandler(_repository);
        var actual = await sut.Handle(new IsOrganisatieNummerUnique { Nummer = "1234", Id = userId });

        Assert.IsFalse(actual);
    }
}
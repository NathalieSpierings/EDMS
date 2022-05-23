using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Users;

namespace Promeetec.EDMS.Domain.Tests.Medewerker.CommandHandlers;


[TestFixture]
public class UpdateMedewerkerHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMedewerkerRepository _repository;
    private IAdresRepository _adresRepository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new MedewerkerRepository(_context);
        _adresRepository = new AdresRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_update_medewerker_and_add_event()
    {
        var userId = Guid.NewGuid();

        var cmd = new CreateMedewerker
        {
            UserId = userId,
            UserDisplayName = "Ad de Admin",

            Id = Guid.NewGuid(),
            OrganisatieId = Guid.NewGuid(),
            OrganisatieDisplayName = "Test organisatie",
            MedewerkerSoort = MedewerkerSoort.Extern,
            Persoon = new Persoon
            {
                Geboortedatum = new DateTime(1975, 07, 22),
                Geslacht = Geslacht.Vrouwelijk,
                Voorletters = "J",
                Voornaam = "Joan",
                Achternaam = "Do",
                TelefoonZakelijk = "1234567897",
                TelefoonPrive = "7894561236",
                Email = "joan.do@test.com",
            },
            Email = "joan.do@test.com",
            Functie = "Recruter",
            AgbCodeZorgverlener = "87654321",
            AgbCodeOnderneming = "12345678",
            IonToestemmingsverklaringActivatieLink = "my link",
            Avatar = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            AccountState = UserAccountState.Test,
            UserName = "0000-jdo",
            TempCode = "1358#$sd%",
            PukCode = "ASD345H78",
            Adres = new Adres
            {
                Straat = "Koeveringsedijk",
                Huisnummer = "5",
                Huisnummertoevoeging = "A",
                Postcode = "5491SB",
                Woonplaats = "Sint Oedenrode",
                LandNaam = "NEDERLAND"
            }
        };

        var medewerker = new Models.Betrokkene.Medewerker.Medewerker(cmd);
        _context.Medewerkers.Add(medewerker);
        await _context.SaveChangesAsync();


        var command = new UpdateMedewerker
        {
            Id = medewerker.Id,
            OrganisatieId = medewerker.OrganisatieId,
            UserId = userId,
            UserDisplayName = "Ad de Admin",
            Persoon = new Persoon
            {
                Geboortedatum = new DateTime(1955, 04, 22),
                Geslacht = Geslacht.Mannelijk,
                Voorletters = "T",
                Tussenvoegsel = "van der",
                Voornaam = "Toon",
                Achternaam = "Zanden",
                TelefoonZakelijk = medewerker.Persoon.TelefoonZakelijk,
                TelefoonPrive = medewerker.Persoon.TelefoonPrive,
                Email = "tvanderzanden@test.com",
            },
            AgbCodeZorgverlener = medewerker.AgbCodeZorgverlener,
            AgbCodeOnderneming = medewerker.AgbCodeOnderneming,
            Email = "tvanderzanden@test.com",
            Functie = medewerker.Functie,
            Avatar = medewerker.Avatar,
            IonToestemmingsverklaringActivatieLink = medewerker.IONToestemmingsverklaringActivatieLink,
            Adres = medewerker.Adres
        };

        var validator = new Mock<IValidator<UpdateMedewerker>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateMedewerkerHandler(_repository, _adresRepository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Medewerkers.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.AreEqual(command.Email, dbEntity.Email);
        Assert.NotNull(@event);
    }
}
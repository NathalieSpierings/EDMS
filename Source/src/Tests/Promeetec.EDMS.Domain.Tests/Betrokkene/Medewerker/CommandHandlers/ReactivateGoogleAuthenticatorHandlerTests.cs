using AutoFixture;
using Microsoft.EntityFrameworkCore;
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

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Medewerker.CommandHandlers;


[TestFixture]
public class ReactivateGoogleAuthenticatorHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMedewerkerRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new MedewerkerRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_reactivate_google_authenticator_and_add_event()
    {
        var cmd = new CreateMedewerker
        {
            UserId = Guid.NewGuid(),
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

        var command = Fixture.Build<ReactivateGoogleAuthenticator>()
            .With(x => x.Id, medewerker.Id)
            .With(x => x.OrganisatieId, medewerker.OrganisatieId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ReactivateGoogleAuthenticatorHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Medewerkers.FirstOrDefaultAsync(x => x.Id == medewerker.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == medewerker.Id);

        Assert.AreEqual(UserAccountState.ReactivateGoogleAuthenticator, dbEntity.AccountState);
        Assert.AreEqual(false, dbEntity.GoogleAuthenticatorEnabled);
        Assert.AreEqual(null, dbEntity.GoogleAuthenticatorSecretKey);
        Assert.AreEqual(false, dbEntity.TwoFactorEnabled);
        Assert.NotNull(@event);
    }
}
using System.Data;
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
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Medewerker.CommandHandlers;


[TestFixture]
public class DeleteMedewerkerHandlerTests : TestFixtureBase
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
    public void ShouldThrowDataExceptionWhenMedewerkerNotFound()
    {
        var sut = new DeleteMedewerkerHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteMedewerker>()));
    }

    [Test]
    public async Task ShouldDeleteMedewerkerAndAddEvent()
    {
        var cmd = new CreateMedewerker
        {
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

        var medewerker1 = new Models.Betrokkene.Medewerker.Medewerker(cmd);

        _context.Medewerkers.Add(medewerker1);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteMedewerker>()
            .With(x => x.Id, medewerker1.Id)
            .With(x => x.OrganisatieId, medewerker1.Id)
            .Create();

        var sut = new DeleteMedewerkerHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var deleted = await _context.Medewerkers.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, deleted.Status);
        Assert.NotNull(@event);
    }
}
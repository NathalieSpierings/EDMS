using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Medewerker
{
    [TestFixture]
    public class MedewerkerTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Medewerker.Medewerker _sut;
        private CreateMedewerker _cmd;
        private Guid _createMedewerkerId;


        [SetUp]
        public void Setup()
        {
            _createMedewerkerId = Guid.NewGuid();

            _cmd = new CreateMedewerker
            {
                Id = _createMedewerkerId,
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

            _sut = new EDMS.Domain.Models.Betrokkene.Medewerker.Medewerker(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createMedewerkerId, _sut.Id);
            Assert.AreEqual(Status.Inactief, _sut.Status);
            Assert.AreEqual(_cmd.MedewerkerSoort, _sut.MedewerkerSoort);
            Assert.AreEqual(_cmd.Persoon.Geslacht, _sut.Persoon.Geslacht);
            Assert.AreEqual(_cmd.Persoon.Geboortedatum, _sut.Persoon.Geboortedatum);
            Assert.AreEqual(_cmd.Persoon.Voorletters, _sut.Persoon.Voorletters);
            Assert.AreEqual(_cmd.Persoon.Tussenvoegsel, _sut.Persoon.Tussenvoegsel);
            Assert.AreEqual(_cmd.Persoon.Voornaam, _sut.Persoon.Voornaam);
            Assert.AreEqual(_cmd.Persoon.Achternaam, _sut.Persoon.Achternaam);
            Assert.AreEqual(_cmd.Persoon.TelefoonZakelijk, _sut.Persoon.TelefoonZakelijk);
            Assert.AreEqual(_cmd.Persoon.TelefoonPrive, _sut.Persoon.TelefoonPrive);
            Assert.AreEqual(_cmd.Persoon.Doorkiesnummer, _sut.Persoon.Doorkiesnummer);
            Assert.AreEqual(_cmd.Persoon.Email, _sut.Persoon.Email);
            Assert.AreEqual(_cmd.Persoon.VolledigeNaam, _sut.Persoon.VolledigeNaam);
            Assert.AreEqual(_cmd.Persoon.FormeleNaam, _sut.Persoon.FormeleNaam);
            Assert.AreEqual(_cmd.AgbCodeZorgverlener, _sut.AgbCodeZorgverlener);
            Assert.AreEqual(_cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(_cmd.Functie, _sut.Functie);
            Assert.AreEqual(_cmd.Avatar, _sut.Avatar);
            Assert.AreEqual(_cmd.Email, _sut.Email);
            Assert.AreEqual(_cmd.IonToestemmingsverklaringActivatieLink, _sut.IONToestemmingsverklaringActivatieLink);
            Assert.AreEqual(_cmd.AccountState, _sut.AccountState);
            Assert.AreEqual(_cmd.UserName, _sut.UserName);
            Assert.AreEqual(_cmd.TempCode, _sut.TempCode);
            Assert.AreEqual(_cmd.PukCode, _sut.PukCode);
            Assert.AreEqual(_cmd.Adres, _sut.Adres);
            Assert.AreEqual(_cmd.UserId, _sut.CreatedById);
            Assert.AreEqual(_cmd.UserDisplayName, _sut.CreatedBy);
            Assert.AreEqual(_cmd.Adres, _sut.Adres);
        }


        [Test]
        public void Update()
        {
            // Gives error on logo byte[]
            // var sut = Fixture.Create<EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie>();

            var cmd = new UpdateMedewerker
            {
                Persoon = new Persoon
                {
                    Voorletters = "D",
                    Tussenvoegsel = "von",
                    Voornaam = "Dita",
                    Achternaam = "Dite",
                    TelefoonZakelijk = "0401234567",
                    TelefoonPrive = "0401234567",
                    Email = "abc@test.com",
                },
                Functie = "New job",
                Email = "abc@test.com",
                AgbCodeZorgverlener = "85296324",
                AgbCodeOnderneming = "74136985",
                IonToestemmingsverklaringActivatieLink ="New link",
                Avatar = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
                Adres = new Adres
                {
                    Straat = "Dorpsstraat",
                    Huisnummer = "37",
                    Postcode = "5735EB",
                    Woonplaats = "Aarle-Rixtel",
                    LandNaam = "NEDERLAND"
                }
            };

            _sut.Update(cmd);

            Assert.AreEqual(cmd.Persoon.Voorletters, _sut.Persoon.Voorletters);
            Assert.AreEqual(cmd.Persoon.Tussenvoegsel, _sut.Persoon.Tussenvoegsel);
            Assert.AreEqual(cmd.Persoon.Voornaam, _sut.Persoon.Voornaam);
            Assert.AreEqual(cmd.Persoon.Achternaam, _sut.Persoon.Achternaam);
            Assert.AreEqual(cmd.Persoon.TelefoonZakelijk, _sut.Persoon.TelefoonZakelijk);
            Assert.AreEqual(cmd.Persoon.TelefoonPrive, _sut.Persoon.TelefoonPrive);
            Assert.AreEqual(cmd.Persoon.Email, _sut.Persoon.Email);
            Assert.AreEqual(cmd.Functie, _sut.Functie);
            Assert.AreEqual(cmd.Email, _sut.Email);
            Assert.AreEqual(cmd.AgbCodeZorgverlener, _sut.AgbCodeZorgverlener);
            Assert.AreEqual(cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(cmd.IonToestemmingsverklaringActivatieLink, _sut.IONToestemmingsverklaringActivatieLink);
            Assert.AreEqual(cmd.Avatar, _sut.Avatar);
            Assert.AreEqual(cmd.Adres, _sut.Adres);
        }

        [Test]
        public void Delete()
        {
            _sut.Delete();
            Assert.AreEqual(Status.Verwijderd, _sut.Status);
        }

        [Test]
        public void Suspend()
        {
            _sut.Suspend(new SuspendMedewerker{DeactivatieReden = "Test deactivatie reden"});
            Assert.AreEqual(Status.Inactief, _sut.Status);
        }

        [Test]
        public void Reinstate()
        {
            _sut.Reinstate();
            Assert.AreEqual(Status.Actief, _sut.Status);
        }
    }
}
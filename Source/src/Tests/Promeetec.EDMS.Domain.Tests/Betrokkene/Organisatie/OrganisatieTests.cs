using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Organisatie
{
    [TestFixture]
    public class OrganisatieTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie _sut;
        private CreateOrganisatie _cmd;
        private Guid _createOrganisatieId;

        [SetUp]
        public void Setup()
        {
            _createOrganisatieId = Guid.NewGuid();

            _cmd = new CreateOrganisatie
            {
                Id = _createOrganisatieId,
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
                    AanleverbestandLocatie = "Test location",
                    AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                    VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
                },
                ContactpersoonId = Guid.NewGuid(),
                ZorggroepRelatieId = Guid.NewGuid(),
                AdresboekId = Guid.NewGuid(),
                AdresId = Guid.NewGuid()
            };

            _sut = new Models.Betrokkene.Organisatie.Organisatie(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createOrganisatieId, _sut.Id);
            Assert.AreEqual(Status.Inactief, _sut.Status);
            Assert.AreEqual(_cmd.Nummer, _sut.Nummer);
            Assert.AreEqual(_cmd.Naam, _sut.Naam);
            Assert.AreEqual(_cmd.TelefoonZakelijk, _sut.TelefoonZakelijk);
            Assert.AreEqual(_cmd.TelefoonPrive, _sut.TelefoonPrive);
            Assert.AreEqual(_cmd.Email, _sut.Email);
            Assert.AreEqual(_cmd.Website, _sut.Website);
            Assert.AreEqual(_cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(_cmd.Zorggroep, _sut.Zorggroep);
            Assert.AreEqual(_cmd.Settings.AanleverbestandLocatie, _sut.Settings.AanleverbestandLocatie);
            Assert.AreEqual(_cmd.Settings.AanleverStatusNaSchrijvenAanleverbestanden, _sut.Settings.AanleverStatusNaSchrijvenAanleverbestanden);
            Assert.AreEqual(_cmd.Settings.VerwijzerInAdresboek, _sut.Settings.VerwijzerInAdresboek);
            Assert.AreEqual(_cmd.ZorggroepRelatieId, _sut.ZorggroepRelatieId);
            Assert.AreEqual(_cmd.ContactpersoonId, _sut.ContactpersoonId);
            Assert.AreEqual(_cmd.AdresId, _sut.AdresId);
            Assert.AreEqual(_cmd.AdresboekId, _sut.AdresboekId);
        }


        [Test]
        public void Update_details()
        {
            // Gives error on logo byte[]
            // var sut = Fixture.Create<EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie>();

            var cmd = new UpdateOrganisatie
            {
                Naam = "New Naam",
                TelefoonZakelijk = "0401234567",
                TelefoonPrive = "0401234567",
                Email = "abc@test.com",
                Website = "http://www.test.com",
                AgbCodeOnderneming = "12345677",
                Zorggroep = true,
                Settings = new OrganisatieSettings
                {
                    AanleverbestandLocatie = "New Test location",
                    AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.Verwerkt,
                    VerwijzerInAdresboek = VerwijzerInAdresboekType.VewijzerOptioneel
                },
                ContactpersoonId = Guid.NewGuid(),
                ZorggroepRelatieId = Guid.NewGuid(),
                AdresId = Guid.NewGuid(),
            };

            _sut.Update(cmd);

            Assert.AreEqual(cmd.Naam, _sut.Naam);
            Assert.AreEqual(cmd.TelefoonZakelijk, _sut.TelefoonZakelijk);
            Assert.AreEqual(cmd.TelefoonPrive, _sut.TelefoonPrive);
            Assert.AreEqual(cmd.Email, _sut.Email);
            Assert.AreEqual(cmd.Website, _sut.Website);
            Assert.AreEqual(cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(cmd.Zorggroep, _sut.Zorggroep);
            Assert.AreEqual(cmd.Settings.AanleverbestandLocatie, _sut.Settings.AanleverbestandLocatie);
            Assert.AreEqual(cmd.Settings.AanleverStatusNaSchrijvenAanleverbestanden, _sut.Settings.AanleverStatusNaSchrijvenAanleverbestanden);
            Assert.AreEqual(cmd.Settings.VerwijzerInAdresboek, _sut.Settings.VerwijzerInAdresboek);
            Assert.AreEqual(cmd.ZorggroepRelatieId, _sut.ZorggroepRelatieId);
            Assert.AreEqual(cmd.ContactpersoonId, _sut.ContactpersoonId);
            Assert.AreEqual(cmd.AdresId, _sut.AdresId);
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
            _sut.Suspend();
            Assert.AreEqual(Status.Inactief, _sut.Status);
        }

        [Test]
        public void Reinstate()
        {
            _sut.Reinstate();
            Assert.AreEqual(Status.Actief, _sut.Status);
        }

        [Test]
        public void Restrict()
        {
            var reason = "Test reason";

            _sut.Restrict(reason);

            Assert.AreEqual(true, _sut.Beperkt);
            Assert.AreEqual(reason, _sut.BeperktReden, nameof(_sut.BeperktReden));
        }

        [Test]
        public void Unrestrict()
        {
            _sut.Unrestrict();
            Assert.AreEqual(false, _sut.Beperkt);
        }
    }
}
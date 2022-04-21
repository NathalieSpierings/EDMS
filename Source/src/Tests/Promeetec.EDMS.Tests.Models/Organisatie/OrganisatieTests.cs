using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Cov;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Tests.Domain.Organisatie
{
    [TestFixture]
    public class OrganisatieTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie _sut;
        private CreateOrganisatie _cmd;
        private Guid _id = Guid.NewGuid();

        const string someValue = "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==";

        [SetUp]
        public void Setup()
        {
            var contactpersoon = new Medewerker { Id = Guid.NewGuid() };
            var zorggroepRelatie = new EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie { Id = Guid.NewGuid() };
            var voorraad = new Voorraad { Id = Guid.NewGuid() };
            var adresboek = new Adresboek { Id = Guid.NewGuid() };
            var adres = new Adres { Id = Guid.NewGuid() };

            _cmd = new CreateOrganisatie
            {
                CreateOrganisatieId = _id,
                Nummer = "9999",
                Naam = "Naam",
                TelefoonZakelijk = "0101234567",
                TelefoonPrive = "0201234567",
                Email = "abc@def.ghi",
                Website = "http://www.test.com",
                AgbCodeOnderneming = "12345678",
                Zorggroep = false,
                Logo = Convert.FromBase64String(someValue),
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                ContactpersoonId = contactpersoon.Id,
                ZorggroepRelatieId = zorggroepRelatie.Id,
                VoorraadId = voorraad.Id,
                AdresboekId = adresboek.Id,
                AdresId = adres.Id
            };

            _sut = new EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_id, _sut.Id);
            Assert.AreEqual(Status.Inactief, _sut.Status);
            Assert.AreEqual(_cmd.Nummer, _sut.Nummer);
            Assert.AreEqual(_cmd.Naam, _sut.Naam);
            Assert.AreEqual(_cmd.TelefoonZakelijk, _sut.TelefoonZakelijk);
            Assert.AreEqual(_cmd.TelefoonPrive, _sut.TelefoonPrive);
            Assert.AreEqual(_cmd.Email, _sut.Email);
            Assert.AreEqual(_cmd.Website, _sut.Website);
            Assert.AreEqual(_cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(_cmd.Zorggroep, _sut.Zorggroep);
            Assert.AreEqual(_cmd.Logo, _sut.Logo);

            Assert.AreEqual(_cmd.IONZoekoptie, _sut.IONZoekoptie);
            Assert.AreEqual(_cmd.AanleverbestandLocatie, _sut.AanleverbestandLocatie);
            Assert.AreEqual(_cmd.AanleverStatusNaSchrijvenAanleverbestanden, _sut.AanleverStatusNaSchrijvenAanleverbestanden);
            Assert.AreEqual(_cmd.COVControleType, _sut.COVControleType);
            Assert.AreEqual(_cmd.COVControleProcessType, _sut.COVControleProcessType);
            Assert.AreEqual(_cmd.VerwijzerInAdresboek, _sut.VerwijzerInAdresboek);

            Assert.AreEqual(_cmd.ZorggroepRelatieId, _sut.ZorggroepRelatieId);
            Assert.AreEqual(_cmd.ContactpersoonId, _sut.ContactpersoonId);
            Assert.AreEqual(_cmd.AdresId, _sut.AdresId);
            Assert.AreEqual(_cmd.VoorraadId, _sut.VoorraadId);
            Assert.AreEqual(_cmd.AdresboekId, _sut.AdresboekId);
        }

        
        [Test]
        public void Update_details()
        {
            var contactpersoon = new Medewerker { Id = Guid.NewGuid() };
            var zorggroepRelatie = new EDMS.Domain.Models.Betrokkene.Organisatie.Organisatie { Id = Guid.NewGuid() };
            var adres = new Adres { Id = Guid.NewGuid() };
            
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
                Logo = Convert.FromBase64String(someValue),
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijk,
                COVControleProcessType = COVControleProcessType.COVProcesStoppenBijUitval,
                COVControleType = COVControleType.COVControleBijVoorraad,
                ContactpersoonId = contactpersoon.Id,
                ZorggroepRelatieId = zorggroepRelatie.Id,
                AdresId = adres.Id
            };

            _sut.Update(cmd);
            
            Assert.AreEqual(cmd.Naam, _sut.Naam);
            Assert.AreEqual(cmd.TelefoonZakelijk, _sut.TelefoonZakelijk);
            Assert.AreEqual(cmd.TelefoonPrive, _sut.TelefoonPrive);
            Assert.AreEqual(cmd.Email, _sut.Email);
            Assert.AreEqual(cmd.Website, _sut.Website);
            Assert.AreEqual(cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(cmd.Zorggroep, _sut.Zorggroep);
            Assert.AreEqual(cmd.Logo, _sut.Logo);

            Assert.AreEqual(cmd.IONZoekoptie, _sut.IONZoekoptie);
            Assert.AreEqual(cmd.AanleverbestandLocatie, _sut.AanleverbestandLocatie);
            Assert.AreEqual(cmd.AanleverStatusNaSchrijvenAanleverbestanden, _sut.AanleverStatusNaSchrijvenAanleverbestanden);
            Assert.AreEqual(cmd.COVControleType, _sut.COVControleType);
            Assert.AreEqual(cmd.COVControleProcessType, _sut.COVControleProcessType);
            Assert.AreEqual(cmd.VerwijzerInAdresboek, _sut.VerwijzerInAdresboek);

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

    }
}
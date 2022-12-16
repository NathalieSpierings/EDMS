using System.Globalization;
using System.Text.RegularExpressions;
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Haarwerk
{
    [TestFixture]
    public class HaarwerkTests : TestFixtureBase
    {
        private Models.Modules.Haarwerk.Haarwerk _sut;
        private CreateHaarwerk _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateHaarwerk>().With(x => x.Id, _createId).Create();
            _sut = new Models.Modules.Haarwerk.Haarwerk(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.OrganisatieId, _sut.OrganisatieId);
            Assert.AreEqual(_cmd.Naam, _sut.Naam);
            Assert.AreEqual(_cmd.Geboortedatum, _sut.Geboortedatum);
            Assert.AreEqual(_cmd.Bsn, _sut.Bsn);
            Assert.AreEqual(_cmd.Verzekeringsnummer, _sut.Verzekeringsnummer);
            Assert.AreEqual(_cmd.Machtigingsnummer, _sut.Machtigingsnummer);
            Assert.AreEqual(_cmd.TypeHulpmiddel, _sut.TypeHulpmiddel);
            Assert.AreEqual(_cmd.LeveringSoort, _sut.LeveringSoort);
            Assert.AreEqual(_cmd.HaarwerkSoort, _sut.HaarwerkSoort);
            Assert.AreEqual(_cmd.Afleverdatum, _sut.Afleverdatum);
            Assert.AreEqual(_cmd.DatumVoorgaandHulpmiddel, _sut.DatumVoorgaandHulpmiddel);
            Assert.AreEqual(_cmd.DatumMedischVoorschrift, _sut.DatumMedischVoorschrift);
            Assert.AreEqual(_cmd.PrijsHaarwerk, _sut.PrijsHaarwerk);
            Assert.AreEqual(_cmd.BedragBasisVerzekering, _sut.BedragBasisVerzekering);
            Assert.AreEqual(_cmd.BedragAanvullendeVerzekering, _sut.BedragAanvullendeVerzekering);
            Assert.AreEqual(_cmd.BedragEigenBijdragen, _sut.BedragEigenBijdragen);
            Assert.AreEqual(_cmd.BedragTeOntvangen, _sut.BedragTeOntvangen);
            Assert.AreEqual(HaarwerkStatus.Nieuw, _sut.Status);
            Assert.AreEqual(HaarwerkCreditType.None, _sut.CreditType);
        }


       

        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateHaarwerk>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Naam, _sut.Naam);
            Assert.AreEqual(cmd.Geboortedatum, _sut.Geboortedatum);
            Assert.AreEqual(cmd.Bsn, _sut.Bsn);
            Assert.AreEqual(cmd.Verzekeringsnummer, _sut.Verzekeringsnummer);
            Assert.AreEqual(cmd.Machtigingsnummer, _sut.Machtigingsnummer);
            Assert.AreEqual(cmd.TypeHulpmiddel, _sut.TypeHulpmiddel);
            Assert.AreEqual(cmd.LeveringSoort, _sut.LeveringSoort);
            Assert.AreEqual(cmd.HaarwerkSoort, _sut.HaarwerkSoort);
            Assert.AreEqual(cmd.Afleverdatum, _sut.Afleverdatum);
            Assert.AreEqual(cmd.DatumVoorgaandHulpmiddel, _sut.DatumVoorgaandHulpmiddel);
            Assert.AreEqual(cmd.DatumMedischVoorschrift, _sut.DatumMedischVoorschrift);
            Assert.AreEqual(cmd.PrijsHaarwerk, _sut.PrijsHaarwerk);
            Assert.AreEqual(cmd.BedragBasisVerzekering, _sut.BedragBasisVerzekering);
            Assert.AreEqual(cmd.BedragAanvullendeVerzekering, _sut.BedragAanvullendeVerzekering);
            Assert.AreEqual(cmd.BedragEigenBijdragen, _sut.BedragEigenBijdragen);
            Assert.AreEqual(cmd.BedragTeOntvangen, _sut.BedragTeOntvangen);
            Assert.AreEqual(HaarwerkStatus.Nieuw, _sut.Status);
            Assert.AreEqual(cmd.CreditType, _sut.CreditType);
        }

        [Test]
        public void Credit()
        {
            var cmd = Fixture.Create<CreditHaarwerk>();
            _sut.Credit(cmd);

            Assert.AreEqual(cmd.OrganisatieId, _sut.OrganisatieId);
            Assert.AreEqual(cmd.Naam, _sut.Naam);
            Assert.AreEqual(cmd.Geboortedatum, _sut.Geboortedatum);
            Assert.AreEqual(cmd.Bsn, _sut.Bsn);
            Assert.AreEqual(cmd.Verzekeringsnummer, _sut.Verzekeringsnummer);
            Assert.AreEqual(cmd.Machtigingsnummer, _sut.Machtigingsnummer);
            Assert.AreEqual(cmd.TypeHulpmiddel, _sut.TypeHulpmiddel);
            Assert.AreEqual(cmd.LeveringSoort, _sut.LeveringSoort);
            Assert.AreEqual(cmd.HaarwerkSoort, _sut.HaarwerkSoort);
            Assert.AreEqual(cmd.Afleverdatum, _sut.Afleverdatum);
            Assert.AreEqual(cmd.DatumVoorgaandHulpmiddel, _sut.DatumVoorgaandHulpmiddel);
            Assert.AreEqual(cmd.DatumMedischVoorschrift, _sut.DatumMedischVoorschrift);
            Assert.AreEqual(cmd.PrijsHaarwerk, _sut.PrijsHaarwerk);
            Assert.AreEqual(cmd.BedragBasisVerzekering, _sut.BedragBasisVerzekering);
            Assert.AreEqual(cmd.BedragAanvullendeVerzekering, _sut.BedragAanvullendeVerzekering);
            Assert.AreEqual(cmd.BedragEigenBijdragen, _sut.BedragEigenBijdragen);
            Assert.AreEqual(cmd.BedragTeOntvangen, _sut.BedragTeOntvangen);
            Assert.AreEqual(HaarwerkStatus.Nieuw, _sut.Status);
            Assert.AreEqual(cmd.CreditType, _sut.CreditType);
        }
    }
}
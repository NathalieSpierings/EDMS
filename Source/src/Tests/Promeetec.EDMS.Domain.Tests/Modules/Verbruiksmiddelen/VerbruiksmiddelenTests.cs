using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Verbruiksmiddelen
{
    [TestFixture]
    public class VerbruiksmiddelenTests : TestFixtureBase
    {
        private VerbruiksmiddelPrestatie _sut;
        private CreateVerbruiksmiddelPrestatie _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateVerbruiksmiddelPrestatie>().With(x => x.Id, _createId).Create();
            _sut = new VerbruiksmiddelPrestatie(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(_cmd.HulpmiddelenSoort, _sut.HulpmiddelenSoort);
            Assert.AreEqual(_cmd.Status, _sut.Status);
            Assert.AreEqual(_cmd.ProfielCode, _sut.ProfielCode);
            Assert.AreEqual(_cmd.ProfielStartdatum, _sut.ProfielStartdatum);
            Assert.AreEqual(_cmd.ProfielEinddatum, _sut.ProfielEinddatum);
            Assert.AreEqual(_cmd.ZIndex, _sut.ZIndex);
            Assert.AreEqual(_cmd.PrestatieDatum, _sut.PrestatieDatum);
            Assert.AreEqual(_cmd.Hoeveelheid, _sut.Hoeveelheid);
            Assert.AreEqual(_cmd.VerzekerdeId, _sut.VerzekerdeId);
            Assert.AreEqual(_cmd.OrganisatieId, _sut.OrganisatieId);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateVerbruiksmiddelPrestatie>();

            _sut.Update(cmd);

            Assert.AreEqual(cmd.AgbCodeOnderneming, _sut.AgbCodeOnderneming);
            Assert.AreEqual(cmd.ZIndex, _sut.ZIndex);
            Assert.AreEqual(cmd.PrestatieDatum, _sut.PrestatieDatum);
            Assert.AreEqual(cmd.Hoeveelheid, _sut.Hoeveelheid);
            Assert.AreEqual(cmd.VerzekerdeId, _sut.VerzekerdeId);
        }

        [Test]
        public void Process()
        {
            _sut.Process();
            Assert.AreEqual(VerbruiksmiddelPrestatieStatus.Verwerkt, _sut.Status);
        }
    }
}
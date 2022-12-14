using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Declaratie.Aanlevering
{
    [TestFixture]
    public class AanleveringTests : TestFixtureBase
    {
        private Models.Modules.Declaratie.Aanlevering.Aanlevering _sut;
        private CreateAanlevering _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateAanlevering>().With(x => x.Id, _createId).Create();
            _sut = new Models.Modules.Declaratie.Aanlevering.Aanlevering(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Referentie, _sut.Referentie);
            Assert.AreEqual(_cmd.ReferentiePromeetec, _sut.ReferentiePromeetec);
            Assert.AreEqual(_cmd.Opmerking, _sut.Opmerking);
            Assert.AreEqual(_cmd.ToevoegenBestand, _sut.ToevoegenBestand);
            Assert.AreEqual(_cmd.OrganisatieId, _sut.OrganisatieId);
            Assert.AreEqual(_cmd.BehandelaarId, _sut.BehandelaarId);
            Assert.AreEqual(_cmd.EigenaarId, _sut.EigenaarId);
            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(AanleverStatus.Aangemaakt, _sut.AanleverStatus);
            Assert.AreEqual(AanleverStatus.Aangemaakt, _sut.AanleverStatus);
            Assert.AreEqual(DateTime.Now.Year, _sut.Jaar);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateAanlevering>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.ReferentiePromeetec, _sut.ReferentiePromeetec);
            Assert.AreEqual(cmd.Opmerking, _sut.Opmerking);
            Assert.AreEqual(cmd.AanleverStatus, _sut.AanleverStatus);
            Assert.AreEqual(cmd.ToevoegenBestand, _sut.ToevoegenBestand);
            Assert.AreEqual(cmd.BehandelaarId, _sut.BehandelaarId);
            Assert.AreEqual(cmd.EigenaarId, _sut.EigenaarId);
        }

        [Test]
        public void Delete()
        {
            var cmd = Fixture.Create<DeleteAanlevering>();
            _sut.Delete(cmd);
            Assert.AreEqual(Status.Verwijderd, _sut.Status);
        }

        [Test]
        public void WijzigEigenaar()
        {
            var cmd = Fixture.Create<ChangeEigenaarAanlevering>();
            _sut.WijzigEigenaar(cmd);
            Assert.AreEqual(cmd.EigenaarId, _sut.EigenaarId);
        }
    }
}
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Behandelplan
{
    [TestFixture]
    public class BehandelplanTests : TestFixtureBase
    {
        private GliBehandelplan _sut;
        private StartBehandeltraject _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<StartBehandeltraject>().With(x => x.Id, _createId).Create();
            _sut = new GliBehandelplan(_cmd);
        }

        [Test]
        public void StartBehandeltraject()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.IntakeId, _sut.IntakeId);
            Assert.AreEqual(_cmd.OrganisatieId, _sut.OrganisatieId);
            Assert.AreEqual(_cmd.VerzekerdeId, _sut.VerzekerdeId);
            Assert.AreEqual(_cmd.BehandelaarId, _sut.BehandelaarId);
            Assert.AreEqual(_cmd.Startdatum, _sut.Startdatum);
            Assert.AreEqual(_cmd.Einddatum, _sut.Einddatum);
            Assert.AreEqual(_cmd.Programma, _sut.GliProgramma);
            Assert.AreEqual(_cmd.Fase, _sut.Fase);
            Assert.AreEqual(_cmd.GliStatus, _sut.GliStatus);
            Assert.AreEqual(_cmd.Opmerking, _sut.Opmerking);
        }

        [Test]
        public void StopBehandeltraject()
        {
            var cmd = Fixture.Create<StopBehandeltraject>();
            _sut.StopBehandeltraject(cmd);

            Assert.AreEqual(cmd.RedenEindeZorgId, _sut.RedenEindeZorgId);
            Assert.AreEqual(cmd.VoortijdigeStopdatum, _sut.VoortijdigeStopdatum);
            Assert.AreEqual(cmd.Opmerking, _sut.Opmerking);
            Assert.AreEqual(true, _sut.VoortijdigGestopt);
            Assert.AreEqual(GliStatus.Gestopt, _sut.GliStatus);
        }

        [Test]
        public void Stopbehandelplan()
        {
            var cmd = Fixture.Create<StopBehandelplan>();
            _sut.Stopbehandelplan(cmd);

            Assert.AreEqual(GliStatus.Gestopt, _sut.GliStatus);
            Assert.AreEqual(true, _sut.VoortijdigGestopt);
            Assert.AreEqual(cmd.VoortijdigeStopdatum, _sut.VoortijdigeStopdatum);
            Assert.AreEqual(cmd.RedenEindeZorgId, _sut.RedenEindeZorgId);
        }

        [Test]
        public void VerwijderBehandeltraject()
        {
            _sut.DeleteBehandeltraject();

            Assert.AreEqual(GliStatus.Verwijderd, _sut.GliStatus);
        }

        [Test]
        public void Process()
        {
            var cmd = Fixture.Create<ProcessBehandelplan>();
            _sut.Process(cmd);

            Assert.AreEqual(true, _sut.Verwerkt);
            Assert.AreEqual(cmd.Status, _sut.GliStatus);
            Assert.AreEqual(cmd.VerwerktOp, _sut.VerwerktOp);
        }


        [Test]
        public void WijzigBehandelplanStatus()
        {
            var cmd = Fixture.Create<UpdateBehandelplanStatus>();
            _sut.UpdateStatus(cmd);

            Assert.AreEqual(cmd.Status, _sut.GliStatus);
        }
    }
}
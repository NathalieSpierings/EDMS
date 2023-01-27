using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Verzekerde
{
    [TestFixture]
    public class VerzekerdeTests : TestFixtureBase
    {
        private Models.Betrokkene.Verzekerde.Verzekerde _sut;
        private CreateVerzekerde _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = Fixture.Build<CreateVerzekerde>()
                .Without(x => x.Adres)
                .With(x => x.Adres, Fixture.Build<Adres>()
                    .Without(x => x.Verzekerden)
                    .Without(x => x.Land)
                    .With(x => x.LandId, Guid.NewGuid())
                    .Create())
                .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                    .Without(x => x.Verzekerden)
                    .Create())
                .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                    .Without(x => x.Verzekerden)
                    .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                        .With(x => x.Id, Guid.NewGuid())
                        .Create())
                    .Create())
                .With(x => x.Id, _createId)
                .Create();

            _sut = new Models.Betrokkene.Verzekerde.Verzekerde(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.AdresboekId, _sut.AdresboekId);
            Assert.AreEqual(_cmd.Adres, _sut.Adres);

            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(_cmd.Bsn, _sut.Bsn);
            Assert.AreEqual(_cmd.Lengte, _sut.Lengte);
            Assert.AreEqual(_cmd.Persoon, _sut.Persoon);
            Assert.AreEqual(_cmd.Zorgverzekering, _sut.Zorgverzekering);
            Assert.AreEqual(_cmd.Zorgprofiel, _sut.Zorgprofiel);
            Assert.AreEqual(_cmd.AgbCodeVerwijzer, _sut.AgbCodeVerwijzer);
            Assert.AreEqual(_cmd.NaamVerwijzer, _sut.NaamVerwijzer);
            Assert.AreEqual(_cmd.Verwijsdatum, _sut.Verwijsdatum);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Build<UpdateVerzekerde>()
                .Without(x => x.Adres)
                .With(x => x.Adres, Fixture.Build<Adres>()
                    .Without(x => x.Verzekerden)
                    .Without(x => x.Land)
                    .With(x => x.LandId, Guid.NewGuid())
                    .Create())
                .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                    .Without(x => x.Verzekerden)
                    .Create())
                .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                    .Without(x => x.Verzekerden)
                    .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                        .With(x => x.Id, Guid.NewGuid())
                        .Create())
                    .Create())
                .With(x => x.Id, _createId)
                .Create();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Bsn, _sut.Bsn);
            Assert.AreEqual(cmd.Persoon, _sut.Persoon);
            Assert.AreEqual(cmd.Adres, _sut.Adres);
            Assert.AreEqual(cmd.Zorgverzekering, _sut.Zorgverzekering);
            Assert.AreEqual(cmd.Zorgprofiel, _sut.Zorgprofiel);
            Assert.AreEqual(cmd.AgbCodeVerwijzer, _sut.AgbCodeVerwijzer);
            Assert.AreEqual(cmd.NaamVerwijzer, _sut.NaamVerwijzer);
            Assert.AreEqual(cmd.Verwijsdatum, _sut.Verwijsdatum);
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
        public void SuspendWithProfile()
        {
            var cmd = Fixture.Create<SuspendVerzekerdeMetZorgprofiel>();
            _sut.SuspendWithProfile(cmd);

            Assert.AreEqual(Status.Inactief, _sut.Status);
            Assert.AreEqual(cmd.ProfielEinddatum, _sut.Zorgprofiel.ProfielEinddatum);
        }

        [Test]
        public void ReinstateWithProfile()
        {
            var cmd = Fixture.Create<ReinstateVerzekerdeMetZorgprofiel>();
            _sut.ReinstateWithProfile(cmd);

            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(cmd.ProfielStartdatum, _sut.Zorgprofiel.ProfielStartdatum);
            Assert.AreEqual(null, _sut.Zorgprofiel.ProfielEinddatum);
        }

        [Test]
        public void Update_length()
        {
            _sut.UpdateLength(1.75);
            Assert.AreEqual(1.75, _sut.Lengte);
        }

        [Test]
        public void Share()
        {
            var cmd = Fixture.Create<AssingVerzekerde>();
            _sut.Share(cmd);

            Assert.AreEqual(cmd.Shared, _sut.Shared);
        }
    }
}
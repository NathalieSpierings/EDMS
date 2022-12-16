using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Zorgstraat
{
    [TestFixture]
    public class ZorgstraatTests : TestFixtureBase
    {
        private Models.Admin.Zorgstraat.Zorgstraat _sut;
        private CreateZorgstraat _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = new CreateZorgstraat
            {
                Id = _createId,
                Naam = "Test zorgstraat"
            };

            _sut = new Models.Admin.Zorgstraat.Zorgstraat(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(_cmd.Naam, _sut.Naam);
        }


        [Test]
        public void Update_details()
        {
            var cmd = new UpdateZorgstraat
            {
                Naam = "Updated zorgstraat"
            };

            _sut.Update(cmd);

            Assert.AreEqual(cmd.Naam, _sut.Naam);
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
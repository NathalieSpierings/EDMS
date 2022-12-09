using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Land
{
    [TestFixture]
    public class LandTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Land.Land _sut;
        private CreateLand _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {

            _cmd = Fixture.Build<CreateLand>().With(x => x.Id, _createId).Create();
            _sut = new Models.Betrokkene.Land.Land(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(_cmd.CultureCode, _sut.CultureCode);
            Assert.AreEqual(_cmd.NativeName, _sut.NativeName);
        }


        [Test]
        public void Update_details()
        {
            var cmd = new UpdateLand
            {
                CultureCode = "en-EN",
                NativeName = "United Kingdom"
            };

            _sut.Update(cmd);

            Assert.AreEqual(cmd.CultureCode, _sut.CultureCode);
            Assert.AreEqual(cmd.NativeName, _sut.NativeName);
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
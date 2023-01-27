using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Declaratie.Aanleverbericht
{
    [TestFixture]
    public class AanleverberichtTests : TestFixtureBase
    {
        private Models.Modules.Declaratie.Aanleverbericht.Aanleverbericht _sut;
        private CreateAanleverbericht _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateAanleverbericht>().With(x => x.Id, _createId).Create();
            _sut = new Models.Modules.Declaratie.Aanleverbericht.Aanleverbericht(_cmd, 0);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(0, _sut.Volgorde);
            Assert.AreEqual(AanleverberichtStatus.Open, _sut.AanleverberichtStatus);
            Assert.AreEqual(_cmd.Onderwerp, _sut.Onderwerp);
            Assert.AreEqual(_cmd.Bericht, _sut.Bericht);
            Assert.AreEqual(false, _sut.Gelezen);
            Assert.AreEqual(_cmd.ParentId, _sut.ParentId);
            Assert.AreEqual(_cmd.AfzenderId, _sut.AfzenderId);
            Assert.AreEqual(_cmd.OntvangerId, _sut.OntvangerId);
            Assert.AreEqual(_cmd.AanleveringId, _sut.AanleveringId);
        }

        [Test]
        public void MarkAsRead()
        {
            var cmd = Fixture.Create<MarkAanleverberichtAsRead>();
            _sut.MarkAsRead(cmd);
            Assert.AreEqual(true, _sut.Gelezen);
            Assert.AreEqual(cmd.LaatsteLezerId, _sut.LaatsteLezerId);

        }

        [Test]
        public void Open()
        {
            _sut.Open();
            Assert.AreEqual(AanleverberichtStatus.Open, _sut.AanleverberichtStatus);
        }

        [Test]
        public void Close()
        {
            _sut.Close();
            Assert.AreEqual(AanleverberichtStatus.Gesloten, _sut.AanleverberichtStatus);
        }
    }
}
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand
{
    [TestFixture]
    public class AanleverbestandTests : TestFixtureBase
    {
        private Models.Document.Aanleverbestand.Aanleverberstand.Aanleverbestand _sut;
        private CreateAanleverbestand _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateAanleverbestand>().With(x => x.Id, _createId).Create();
            _sut = new Models.Document.Aanleverbestand.Aanleverberstand.Aanleverbestand(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.FileName, _sut.FileName);
            Assert.AreEqual(_cmd.Extension, _sut.Extension);
            Assert.AreEqual(_cmd.FileSize, _sut.FileSize);
            Assert.AreEqual(_cmd.MimeType, _sut.MimeType);
            Assert.AreEqual(_cmd.Data, _sut.Data);
            Assert.AreEqual(_cmd.Data, _sut.Data);
            Assert.AreEqual(_cmd.ZorgstraatId, _sut.ZorgstraatId);
            Assert.AreEqual(_cmd.EiStandaardId, _sut.EiStandaardId);
            Assert.AreEqual(_cmd.AanleveringId, _sut.AanleveringId);
            Assert.AreEqual(_cmd.EigenaarId, _sut.EigenaarId);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateAanleverbestand>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Periode, _sut.Periode);
            Assert.AreEqual(cmd.ZorgstraatId, _sut.ZorgstraatId);
            Assert.AreEqual(cmd.EigenaarId, _sut.EigenaarId);
        }

        [Test]
        public void Check()
        {
            _sut.Check();
            Assert.AreEqual(true, _sut.Gecontroleerd);
        }

        [Test]
        public void Uncheck()
        {
            _sut.Uncheck();
            Assert.AreEqual(false, _sut.Gecontroleerd);
        }
    }
}
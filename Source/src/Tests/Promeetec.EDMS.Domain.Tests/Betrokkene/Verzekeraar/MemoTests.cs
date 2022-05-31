using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Commands;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekeraar
{
    [TestFixture]
    public class VerzekeraarTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Verzekeraar.Verzekeraar _sut;
        private CreateVerzekeraar _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = new CreateVerzekeraar
            {
                Id = _createId,
                Uzovi = 14523,
                Naam = "This is the name of the verzekeraar.",
                Actief = true
            };

            _sut = new Models.Betrokkene.Verzekeraar.Verzekeraar(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Uzovi, _sut.Uzovi);
            Assert.AreEqual(_cmd.Naam, _sut.Naam);
            Assert.AreEqual(true, _sut.Actief);
        }
    }
}
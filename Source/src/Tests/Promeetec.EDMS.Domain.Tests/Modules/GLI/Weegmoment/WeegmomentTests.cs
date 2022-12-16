using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Weegmoment
{
    [TestFixture]
    public class WeegmomentTests : TestFixtureBase
    {
        private Models.Modules.GLI.Weegmoment.Weegmoment _sut;
        private CreateWeegmoment _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateWeegmoment>().With(x => x.Id, _createId).Create();
            _sut = new Models.Modules.GLI.Weegmoment.Weegmoment(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Gewicht, _sut.Gewicht);
            Assert.AreEqual(_cmd.VerzekerdeId, _sut.VerzekerdeId);
        }
    }
}
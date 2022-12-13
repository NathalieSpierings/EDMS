using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Mededeling
{
    [TestFixture]
    public class MededelingTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Admin.Mededeling.Mededeling _sut;
        private CreateMededeling _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = new CreateMededeling
            {
                Id = _createId,
                Content = "This is the content of my message."
            };

            _sut = new Models.Admin.Mededeling.Mededeling(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Content, _sut.Content);
        }
    }
}
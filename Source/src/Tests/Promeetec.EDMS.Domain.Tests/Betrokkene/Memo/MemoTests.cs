using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Memo
{
    [TestFixture]
    public class MemoTests : TestFixtureBase
    {
        private EDMS.Domain.Models.Betrokkene.Memo.Memo _sut;
        private CreateMemo _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = new CreateMemo
            {
                Id = _createId,
                MedewerkerId = Guid.NewGuid(),
                Date = DateTime.Now,
                Content = "This is the content of my memo."
            };

            _sut = new Models.Betrokkene.Memo.Memo(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.MedewerkerId, _sut.MedewerkerId);
            Assert.AreEqual(_cmd.Date, _sut.Date);
            Assert.AreEqual(_cmd.Content, _sut.Content);
        }
    }
}
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Changelog
{
    [TestFixture]
    public class ChangelogTests : TestFixtureBase
    {
        private Models.Changelog.Changelog _sut;
        private CreateChangelogPost _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateChangelogPost>().With(x => x.Id, _createId).Create();
            _sut = new Models.Changelog.Changelog(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Date, _sut.Date);
            Assert.AreEqual(_cmd.Title, _sut.Title);
            Assert.AreEqual(_cmd.Description, _sut.Description);
            Assert.AreEqual(_cmd.Content, _sut.Content);
            Assert.AreEqual(_cmd.Type, _sut.Type);
            Assert.AreEqual(_cmd.Tag, _sut.Tag);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateChangelogPost>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Date, _sut.Date);
            Assert.AreEqual(cmd.Title, _sut.Title);
            Assert.AreEqual(cmd.Description, _sut.Description);
            Assert.AreEqual(cmd.Content, _sut.Content);
            Assert.AreEqual(cmd.Type, _sut.Type);
            Assert.AreEqual(cmd.Tag, _sut.Tag);
        }
    }
}
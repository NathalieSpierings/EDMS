using System.Data;
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.PushMessage
{
    [TestFixture]
    public class PushMessageTests : TestFixtureBase
    {
        private Models.Admin.PushMessage.PushMessage _sut;
        private CreatePushMessage _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreatePushMessage>()
                .With(x => x.Id, _createId)
                .Without(x => x.Groups)
                .With(x => x.Groups, Fixture.Build<Group>()
                    .Without(x => x.Roles)
                    .Without(x => x.Users)
                    .CreateMany().ToList())
                .Create();

            _sut = new Models.Admin.PushMessage.PushMessage(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Title, _sut.Title);
            Assert.AreEqual(_cmd.Message, _sut.Message);
            Assert.AreEqual(_cmd.Status, _sut.Status);
            Assert.AreEqual(string.Join(",", _cmd.GroupIds.ToArray()), _sut.GroupIds);
        }


        [Test]
        public void RemoveUser()
        {
            var cmd = Fixture.Create<RemoveUserFromPushMessage>();
            Assert.Throws<DataException>(() => _sut.RemoveUser(cmd));
        }
        
        [Test]
        public void Publish()
        {
            _sut.Publish();
            Assert.AreEqual(PushMessageStatus.Gepubliceerd, _sut.Status);
        }

    }
}
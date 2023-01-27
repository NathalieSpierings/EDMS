using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Identity.Role
{
    [TestFixture]
    public class RoleTests : TestFixtureBase
    {
        private Models.Identity.Role.Role _sut;
        private CreateRole _cmd;
        private Guid _createId;

        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateRole>().With(x => x.Id, _createId).Create();
            _sut = new Models.Identity.Role.Role(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(_cmd.Name, _sut.Name);
            Assert.AreEqual(_cmd.Description, _sut.Description);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Build<UpdateRole>().With(x => x.Id, _createId).Create();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Name, _sut.Name);
            Assert.AreEqual(cmd.Description, _sut.Description);
        }

        [Test]
        public void Delete()
        {
            _sut.Delete();
            Assert.AreEqual(Status.Verwijderd, _sut.Status);
        }
    }
}
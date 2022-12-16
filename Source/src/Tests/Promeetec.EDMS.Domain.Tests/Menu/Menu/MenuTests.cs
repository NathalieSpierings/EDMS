using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.Menu
{
    [TestFixture]
    public class MenuTests : TestFixtureBase
    {
        private Models.Menu.Menu.Menu _sut;
        private CreateMenu _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateMenu>().With(x => x.Id, _createId).Create();
            _sut = new Models.Menu.Menu.Menu(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(Status.Actief, _sut.Status);
            Assert.AreEqual(_cmd.Name, _sut.Name);
            Assert.AreEqual(_cmd.MenuType, _sut.MenuType);
        }


        [Test]
        public void Update_details()
        {
            var cmd = new Fixture().Create<UpdateMenu>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.Name, _sut.Name);
            Assert.AreEqual(cmd.MenuType, _sut.MenuType);
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
using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.UserProfile
{
    [TestFixture]
    public class UserProfileTests : TestFixtureBase
    {
        private Models.Betrokkene.UserProfile.UserProfile _sut;
        private CreateUserProfile _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateUserProfile>().With(x => x.Id, _createId).Create();
            _sut = new Models.Betrokkene.UserProfile.UserProfile(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.PageSize, _sut.PageSize);
            Assert.AreEqual(_cmd.TableLayout, _sut.TableLayout);
            Assert.AreEqual(_cmd.SidebarLayout, _sut.SidebarLayout);
            Assert.AreEqual(_cmd.AanleverstatusIds, _sut.AanleverstatusIds);
            Assert.AreEqual(_cmd.EmailBijAanleverbericht, _sut.EmailBijAanleverbericht);
            Assert.AreEqual(_cmd.EmailBijToevoegenDocument, _sut.EmailBijToevoegenDocument);
            Assert.AreEqual(_cmd.EmailBijRapportage, _sut.EmailBijRapportage);
            Assert.AreEqual(_cmd.CarbonCopyAdressen, _sut.CarbonCopyAdressen);
        }


        [Test]
        public void Update_details()
        {
            var cmd = Fixture.Create<UpdateUserProfile>();
            _sut.Update(cmd);

            Assert.AreEqual(cmd.PageSize, _sut.PageSize);
            Assert.AreEqual(cmd.TableLayout, _sut.TableLayout);
            Assert.AreEqual(cmd.SidebarLayout, _sut.SidebarLayout);
            Assert.AreEqual(cmd.AanleverstatusIds, _sut.AanleverstatusIds);
            Assert.AreEqual(cmd.EmailBijAanleverbericht, _sut.EmailBijAanleverbericht);
            Assert.AreEqual(cmd.EmailBijToevoegenDocument, _sut.EmailBijToevoegenDocument);
            Assert.AreEqual(cmd.EmailBijRapportage, _sut.EmailBijRapportage);
            Assert.AreEqual(cmd.CarbonCopyAdressen, _sut.CarbonCopyAdressen);
        }

        [Test]
        public void UpdatePageSize()
        {
            var cmd = Fixture.Create<UpdatePageSize>();
            _sut.UpdatePageSize(cmd);
            Assert.AreEqual(cmd.PageSize, _sut.PageSize);
        }

        [Test]
        public void UpdateEmailBijRapportage()
        {
            var cmd = Fixture.Create<UpdateEmailBijRapportage>();
            _sut.UpdateEmailBijRapportage(cmd);
            Assert.AreEqual(cmd.EmailBijRapportage, _sut.EmailBijRapportage);
        }
    }
}
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Notification
{
    [TestFixture]
    public class NotificationTests : TestFixtureBase
    {
        private Notificatie _sut;
        private CreateNotificatie _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _cmd = new CreateNotificatie
            {
                Id = _createId,
                OntvangerId = Guid.NewGuid(),
                Titel = "Notification title",
                Bericht = "This is the content of my notification",
                Url = "http://localhost:noti",
                NotificatieType = NotificatieType.Aanleverstatus,
                NotificatieStatus = NotificatieStatus.Nieuw,
                Datum = DateTime.Now
            };

            _sut = new Notificatie(_cmd);
        }

        [Test]
        public void New()
        {
            Assert.AreEqual(_createId, _sut.Id);
            Assert.AreEqual(_cmd.Datum.ToShortDateString(), _sut.Datum.ToShortDateString());
            Assert.AreEqual(_cmd.Titel, _sut.Titel);
            Assert.AreEqual(_cmd.Bericht, _sut.Bericht);
            Assert.AreEqual(_cmd.Url, _sut.Url);
            Assert.AreEqual(_cmd.NotificatieType, _sut.NotificatieType);
            Assert.AreEqual(_cmd.NotificatieStatus, _sut.NotificatieStatus);
            Assert.AreEqual(_cmd.OntvangerId, _sut.MedewerkerId);
        }
    }
}
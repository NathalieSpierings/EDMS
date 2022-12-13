using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.Settings;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Settings
{
    [TestFixture]
    public class SettingsTests : TestFixtureBase
    {
        private Models.Admin.Settings.Settings _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Fixture.Create<Models.Admin.Settings.Settings>();
        }

        [Test]
        public void Update_settings()
        {
            var cmd = new UpdateSettings
            {
                Straat = "New street",
                Huisnummer = "55",
                Huisnummertoevoeging = "A",
                Postcode = "1011DB",
                Woonplaats = "Broekland",
                Telefoon = "0401234567",
                Email = "info@test.nl",
                Haarwerk = new SettingsHaarwerk
                {
                    BedragBasisVerzekeringHaarwerk = new decimal(12.25)
                }
            };

            _sut.Update(cmd);

            Assert.AreEqual(cmd.Straat, _sut.Straat);
            Assert.AreEqual(cmd.Huisnummer, _sut.Huisnummer);
            Assert.AreEqual(cmd.Huisnummertoevoeging, _sut.Huisnummertoevoeging);
            Assert.AreEqual(cmd.Postcode, _sut.Postcode);
            Assert.AreEqual(cmd.Woonplaats, _sut.Woonplaats);
            Assert.AreEqual(cmd.Telefoon, _sut.Telefoon);
            Assert.AreEqual(cmd.Email, _sut.Email);
            Assert.AreEqual(cmd.Haarwerk.BedragBasisVerzekeringHaarwerk, _sut.Haarwerk.BedragBasisVerzekeringHaarwerk);

        }
    }
}
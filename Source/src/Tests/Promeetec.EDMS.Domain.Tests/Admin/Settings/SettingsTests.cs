using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;
using Promeetec.EDMS.Tests.Helpers;

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
            var command = Fixture.Create<UpdateSettings>();
            _sut.Update(command);

            Assert.AreEqual(command.Straat, _sut.Straat);
            Assert.AreEqual(command.Huisnummer, _sut.Huisnummer);
            Assert.AreEqual(command.Huisnummertoevoeging, _sut.Huisnummertoevoeging);
            Assert.AreEqual(command.Postcode, _sut.Postcode);
            Assert.AreEqual(command.Woonplaats, _sut.Woonplaats);
            Assert.AreEqual(command.Telefoon, _sut.Telefoon);
            Assert.AreEqual(command.Email, _sut.Email);
            Assert.AreEqual(command.Haarwerk.BedragBasisVerzekeringHaarwerk, _sut.Haarwerk.BedragBasisVerzekeringHaarwerk);
        }
    }
}
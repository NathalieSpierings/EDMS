using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Intake
{
    [TestFixture]
    public class IntakeTests : TestFixtureBase
    {
        private GliIntake _sut;
        private CreateIntake _cmd;
        private Guid _createId;
        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();
            _cmd = Fixture.Build<CreateIntake>().With(x => x.Id, _createId).Create();
            _sut = new GliIntake(_cmd);
        }

        //[Test]
        //public void New()
        //{
        //    Assert.AreEqual(_createId, _sut.Id);
        //    Assert.AreEqual(Status.Actief, _sut.Status);
        //    Assert.AreEqual(_cmd.CultureCode, _sut.CultureCode);
        //    Assert.AreEqual(_cmd.NativeName, _sut.NativeName);
        //}


        //[Test]
        //public void Update_details()
        //{
        //    var cmd = new UpdateIntake
        //    {
        //        CultureCode = "en-EN",
        //        NativeName = "United Kingdom"
        //    };

        //    _sut.Update(cmd);

        //    Assert.AreEqual(cmd.CultureCode, _sut.CultureCode);
        //    Assert.AreEqual(cmd.NativeName, _sut.NativeName);
        //}

        //[Test]
        //public void Delete()
        //{
        //    _sut.Delete();
        //    Assert.AreEqual(Status.Verwijderd, _sut.Status);
        //}

        //[Test]
        //public void Suspend()
        //{
        //    _sut.Suspend();
        //    Assert.AreEqual(Status.Inactief, _sut.Status);
        //}

        //[Test]
        //public void Reinstate()
        //{
        //    _sut.Reinstate();
        //    Assert.AreEqual(Status.Actief, _sut.Status);
        //}

    }
}
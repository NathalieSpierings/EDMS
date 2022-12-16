using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Rapportage
{
    [TestFixture]
	public class RapportageTests : TestFixtureBase
	{
		private Models.Document.Rapportage.Rapportage _sut;
		private CreateRapportage _cmd;
		private Guid _createId;

		[SetUp]
		public void Setup()
		{
			_createId = Guid.NewGuid();
			_cmd = Fixture.Build<CreateRapportage>().With(x => x.Id, _createId).Create();
			_sut = new Models.Document.Rapportage.Rapportage(_cmd);
		}

		[Test]
		public void New()
		{
			Assert.AreEqual(_createId, _sut.Id);
			Assert.AreEqual(_cmd.FileName, _sut.FileName);
			Assert.AreEqual(_cmd.Extension, _sut.Extension);
			Assert.AreEqual(_cmd.FileSize, _sut.FileSize);
			Assert.AreEqual(_cmd.MimeType, _sut.MimeType);
			Assert.AreEqual(_cmd.Data, _sut.Data);
			Assert.AreEqual(_cmd.EigenaarId, _sut.EigenaarId);
			Assert.AreEqual(_cmd.OrganisatieId, _sut.OrganisatieId);
			Assert.AreEqual(_cmd.Referentie, _sut.Referentie);
			Assert.AreEqual(_cmd.RapportageSoort, _sut.RapportageSoort);
		}
	}
}
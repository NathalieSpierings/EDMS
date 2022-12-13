using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Bestand
{
    [TestFixture]
	public class BestandTests : TestFixtureBase
	{
		private Models.Document.Bestand.Bestand _sut;
		private CreateBestand _cmd;
		private Guid _createId;

		[SetUp]
		public void Setup()
		{
			_createId = Guid.NewGuid();
			_cmd = Fixture.Build<CreateBestand>().With(x => x.Id, _createId).Create();
			_sut = new Models.Document.Bestand.Bestand(_cmd);
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
		}


		[Test]
		public void Update_details()
		{
			var cmd = Fixture.Create<UpdateBestand>();
			_sut.Update(cmd);

			Assert.AreEqual(cmd.FileName, _sut.FileName);
			Assert.AreEqual(cmd.EigenaarId, _sut.EigenaarId);
		}
	}
}
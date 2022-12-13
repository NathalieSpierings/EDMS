using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Overigbestand
{
    [TestFixture]
	public class OverigbestandTests : TestFixtureBase
	{
		private Models.Document.Overigbestand.Overigbestand _sut;
		private CreateOverigBestand _cmd;
		private Guid _createId;

		[SetUp]
		public void Setup()
		{
			_createId = Guid.NewGuid();
			_cmd = Fixture.Build<CreateOverigBestand>().With(x => x.Id, _createId).Create();
			_sut = new Models.Document.Overigbestand.Overigbestand(_cmd);
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
			Assert.AreEqual(_cmd.AanleveringId, _sut.AanleveringId);
		}
	}
}
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand.CommandHandlers;


[TestFixture]
public class CheckAanleverbestandHandlerTests : TestFixtureBase
{
	private EDMSDbContext _context;
	private IAanleverbestandRepository _repository;

	[SetUp]
	public void Setup()
	{
		_context = new EDMSDbContext(Shared.CreateContextOptions());

		_repository = new AanleverbestandRepository(_context);
	}


	[Test]
	public async Task Should_check_aanleverbestand()
	{
		var cmd = Fixture.Create<CreateAanleverbestand>();
		var bestand = new Models.Document.Aanleverbestand.Aanleverberstand.Aanleverbestand(cmd);
		_context.Aanleverbestanden.Add(bestand);
		await _context.SaveChangesAsync();

		var command = Fixture.Build<CheckAanleverbestand>()
			.With(x => x.Id, bestand.Id)
			.With(x => x.OrganisatieId, cmd.OrganisatieId)
			.With(x => x.UserId, Guid.NewGuid())
			.With(x => x.UserDisplayName, "Ad de Admin")
			.Create();

		var sut = new CheckAanleverbestandHandler(_repository);
		await sut.Handle(command);

		var dbEntity = await _context.Aanleverbestanden.FirstOrDefaultAsync(x => x.Id == bestand.Id);

		Assert.NotNull(dbEntity);
		Assert.AreEqual(true, dbEntity?.Gecontroleerd);
	}
}
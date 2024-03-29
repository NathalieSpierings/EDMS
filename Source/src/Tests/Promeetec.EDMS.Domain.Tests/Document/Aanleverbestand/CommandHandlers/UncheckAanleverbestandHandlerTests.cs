﻿using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Document.Aanleverbestand.CommandHandlers;


[TestFixture]
public class UncheckAanleverbestandHandlerTests : TestFixtureBase
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

		var command = Fixture.Build<UncheckAanleverbestand>()
			.With(x => x.Id, bestand.Id)
			.With(x => x.OrganisatieId, cmd.OrganisatieId)
			.With(x => x.UserId, Guid.NewGuid())
			.With(x => x.UserDisplayName, "Ad de Admin")
			.Create();

		var sut = new UncheckAanleverbestandHandler(_repository);
		await sut.Handle(command);

		var dbEntity = await _context.Aanleverbestanden.FirstOrDefaultAsync(x => x.Id == bestand.Id);

		Assert.NotNull(dbEntity);
		Assert.AreEqual(false, dbEntity?.Gecontroleerd);
	}
}

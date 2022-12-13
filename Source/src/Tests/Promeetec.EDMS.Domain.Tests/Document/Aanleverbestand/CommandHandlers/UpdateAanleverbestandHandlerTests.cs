using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand.CommandHandlers;


[TestFixture]
public class UpdateAanleverbestandHandlerTests : TestFixtureBase
{
	private EDMSDbContext _context;
	private IAanleverbestandRepository _repository;
	private IEventRepository _eventRepository;

	[SetUp]
	public void Setup()
	{
		_context = new EDMSDbContext(Shared.CreateContextOptions());

		_repository = new AanleverbestandRepository(_context);
		_eventRepository = new EventRepository(_context);
	}

	[Test]
	public async Task Should_update_aanleverbestand_and_add_event()
	{
		var cmd = Fixture.Create<CreateAanleverbestand>();

		var bestand = new Models.Document.Aanleverbestand.Aanleverberstand.Aanleverbestand(cmd);
		_context.Aanleverbestanden.Add(bestand);
		await _context.SaveChangesAsync();

		var command = Fixture.Build<UpdateAanleverbestand>()
			.With(x => x.Id, bestand.Id)
			.With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, cmd.OrganisatieId)
			.With(x => x.UserDisplayName, "Ad de Admin")
			.Create();


		var validator = new Mock<IValidator<UpdateAanleverbestand>>();
		validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

		var sut = new UpdateAanleverbestandHandler(_repository, _eventRepository, validator.Object);
		await sut.Handle(command);

		var dbEntity = await _context.Aanleverbestanden.FirstOrDefaultAsync(x => x.Id == bestand.Id);
		var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == bestand.Id);

		validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
		Assert.NotNull(dbEntity);
		Assert.NotNull(@event);
	}
}
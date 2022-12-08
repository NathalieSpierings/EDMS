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

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand.CommandHandlers;


[TestFixture]
public class CreateAanleverbestandHandlerTests : TestFixtureBase
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
	public async Task Should_create_new_country_and_add_event()
	{
		var command = Fixture.Create<CreateAanleverbestand>();

		var validator = new Mock<IValidator<CreateAanleverbestand>>();
		validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

		var sut = new CreateAanleverbestandHandler(_repository, _eventRepository, validator.Object);

		await sut.Handle(command);

		var dbEntity = await _context.Aanleverbestanden.FirstOrDefaultAsync(x => x.Id == command.Id);
		var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

		validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
		Assert.NotNull(dbEntity);
		Assert.NotNull(@event);
	}
}
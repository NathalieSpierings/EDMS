using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Organisatie.CommandHandlers;


[TestFixture]
public class CreateOrganisatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IOrganisatieRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new OrganisatieRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_create_new_organisatie_and_add_event()
    {
        var command = Fixture.Create<CreateOrganisatie>();

        var validator = new Mock<IValidator<CreateOrganisatie>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateOrganisatieHandler(_repository, _eventRepository, validator.Object);

        await sut.Handle(command);

        var dbEntity = await _context.Organisaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
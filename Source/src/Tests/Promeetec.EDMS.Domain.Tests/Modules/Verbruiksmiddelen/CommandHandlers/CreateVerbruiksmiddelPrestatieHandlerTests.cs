using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Verbruiksmiddelen.CommandHandlers;


[TestFixture]
public class CreateVerbruiksmiddelPrestatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerbruiksmiddelPrestatieRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new VerbruiksmiddelPrestatieRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_prestatie_and_add_event()
    {
        var command = Fixture.Create<CreateVerbruiksmiddelPrestatie>();
        var validator = new Mock<IValidator<CreateVerbruiksmiddelPrestatie>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateVerbruiksmiddelPrestatieHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.VerbruiksmiddelPrestaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
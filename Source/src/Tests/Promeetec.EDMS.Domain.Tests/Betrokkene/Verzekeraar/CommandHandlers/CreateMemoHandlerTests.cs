using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Handlers;
using Promeetec.EDMS.Domain.Models.Event;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekeraar.CommandHandlers;


[TestFixture]
public class CreateVerzekeraarHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerzekeraarRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new VerzekeraarRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_memo_and_add_event()
    {
        var command = Fixture.Create<CreateVerzekeraar>();

        var validator = new Mock<IValidator<CreateVerzekeraar>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateVerzekeraarHandler(_repository, _eventRepository, validator.Object);

        await sut.Handle(command);

        var dbEntity = await _context.Verzekeraars.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
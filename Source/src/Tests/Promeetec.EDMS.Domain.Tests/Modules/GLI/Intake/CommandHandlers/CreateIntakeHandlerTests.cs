﻿using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Intake.CommandHandlers;


[TestFixture]
public class CreateIntakeHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGliIntakeRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new GliIntakeRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_intake_and_add_event()
    {
        var command = Fixture.Create<CreateIntake>();
        var validator = new Mock<IValidator<CreateIntake>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateIntakeHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.GliIntakes.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
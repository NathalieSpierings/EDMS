using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Intake.CommandHandlers;


[TestFixture]
public class UpdateIntakeHandlerTests : TestFixtureBase
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
    public async Task Should_update_intake_and_add_event()
    {
        var cmd = Fixture.Build<CreateIntake>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var intake = new GliIntake(cmd);
        _context.GliIntakes.Add(intake);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateIntake>()
            .With(x => x.Id, intake.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateIntake>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateIntakeHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.GliIntakes.FirstOrDefaultAsync(x => x.Id == intake.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == intake.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Opmerking, dbEntity?.Opmerking);
        Assert.NotNull(@event);
    }
}
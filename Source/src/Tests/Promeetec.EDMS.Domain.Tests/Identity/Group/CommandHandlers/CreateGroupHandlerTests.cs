using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Identity.Group.CommandHandlers;


[TestFixture]
public class CreateGroupHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IGroupRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new GroupRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_group_and_add_event()
    {
        var command = Fixture.Create<CreateGroup>();

        var validator = new Mock<IValidator<CreateGroup>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateGroupHandler(_repository, _eventRepository, validator.Object);

        await sut.Handle(command);

        var dbEntity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
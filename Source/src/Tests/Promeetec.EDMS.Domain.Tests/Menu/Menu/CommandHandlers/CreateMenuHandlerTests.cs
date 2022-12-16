using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.Menu.CommandHandlers;


[TestFixture]
public class CreateMenuHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMenuRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new MenuRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_create_new_menu_and_add_event()
    {
        var command = Fixture.Create<CreateMenu>();

        var validator = new Mock<IValidator<CreateMenu>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateMenuHandler(_repository, _eventRepository, validator.Object);

        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
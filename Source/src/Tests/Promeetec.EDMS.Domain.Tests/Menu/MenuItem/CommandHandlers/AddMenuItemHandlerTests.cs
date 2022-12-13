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
using Promeetec.EDMS.Domain.Models.Menu.MenuItem;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.MenuItem.CommandHandlers;


[TestFixture]
public class AddMenuItemHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    // private IMenuRepository _menuRepository;
    // private IMenuItemRepository _repository;
     private IMenuRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        // _menuRepository = new MenuRepository(_context);
        // _repository = new MenuItemRepository(_context);
        _repository = new MenuRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_exception_if_menu_not_found()
    {
        var command = Fixture.Create<AddMenuItem>();

        var repositoryMock = new Mock<IMenuRepository>();
        repositoryMock.Setup(x => x.GetByIdAsync(command.MenuId)).ReturnsAsync((Models.Menu.Menu.Menu)null);

        var validatorMock = new Mock<IValidator<AddMenuItem>>();

        var handler = new AddMenuItemHandler(repositoryMock.Object, _eventRepository);

        Assert.Throws<Exception>(() => handler.Handle(command));
    }


    [Test]
    public async Task Should_create_new_menu_item_and_add_event()
    {
        var command = Fixture.Create<AddMenuItem>();

        var validator = new Mock<IValidator<AddMenuItem>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new AddMenuItemHandler(_repository, _eventRepository);

        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
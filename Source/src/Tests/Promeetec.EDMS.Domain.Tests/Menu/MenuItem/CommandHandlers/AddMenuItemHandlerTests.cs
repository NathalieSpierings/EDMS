using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.MenuItem.CommandHandlers;


[TestFixture]
public class AddMenuItemHandlerTests : TestFixtureBase
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
    public void Should_throw_data_exception_when_menu_not_found()
    {
        var sut = new AddMenuItemHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Build<AddMenuItem>().Without(x => x.Roles).Create()));
    }



    [Test]
    public async Task Should_create_new_menu_item_and_add_event()
    {
        var cmd = Fixture.Build<CreateMenu>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var menu = new Models.Menu.Menu.Menu(cmd);
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<AddMenuItem>()
            .Without(x => x.Roles)
            .With(x => x.MenuId, menu.Id)
            .Create();

        var sut = new AddMenuItemHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
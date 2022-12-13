using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.MenuItem.CommandHandlers;


[TestFixture]
public class RemoveMenuItemHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMenuItemRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new MenuItemRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_menu_not_found()
    {
        var sut = new RemoveMenuItemHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<RemoveMenuItem>()));
    }

    [Test]
    public async Task Should_delete_menu_and_add_event()
    {
        var cmd = Fixture.Build<RemoveMenuItem>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var Menu = new Models.Menu.Menu(cmd);
        _context.Menus.Add(Menu);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<RemoveMenuItem>()
            .With(x => x.Id, Menu.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new RemoveMenuItemHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
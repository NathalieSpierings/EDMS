using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Handlers;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.Menu.CommandHandlers;


[TestFixture]
public class SuspendMenuHandlerTests : TestFixtureBase
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
    public async Task Should_suspend_menu_and_add_event()
    {
        var cmd = Fixture.Build<CreateMenu>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var Menu = new Models.Menu.Menu.Menu(cmd);
        _context.Menus.Add(Menu);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<SuspendMenu>()
            .With(x => x.Id, Menu.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new SuspendMenuHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == Menu.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Menu.Id);

        Assert.AreEqual(Status.Inactief, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
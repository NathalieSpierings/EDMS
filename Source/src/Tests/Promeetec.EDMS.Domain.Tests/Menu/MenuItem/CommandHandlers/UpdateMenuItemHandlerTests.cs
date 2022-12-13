using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.MenuItem.CommandHandlers;


[TestFixture]
public class UpdateMenuItemHandlerTests : TestFixtureBase
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
    public async Task Should_update_menu_item_and_add_event()
    {
        var cmd = Fixture.Build<UpdateMenuItem>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var Menu = new Models.Menu.Menu(cmd);
        _context.Menus.Add(Menu);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateMenuItem>()
            .With(x => x.Id, Menu.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateMenu>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateMenuItemHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == Menu.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Menu.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Name, dbEntity.Name);
        Assert.NotNull(@event);
    }
}
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
public class UpdateMenuHandlerTests : TestFixtureBase
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
    public async Task Should_update_menu_and_add_event()
    {
        var cmd = Fixture.Build<CreateMenu>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var menu = new Models.Menu.Menu.Menu(cmd);
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateMenu>()
            .With(x => x.Id, menu.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateMenu>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateMenuHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == menu.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Name, dbEntity?.Name);
        Assert.NotNull(@event);
    }
}
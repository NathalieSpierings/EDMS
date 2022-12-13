using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group.Handlers;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Identity.Group.CommandHandlers;


[TestFixture]
public class DeleteGroupHandlerTests : TestFixtureBase
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
    public void Should_throw_data_exception_when_group_not_found()
    {
        var sut = new DeleteGroupHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteGroup>()));
    }

    [Test]
    public async Task Should_delete_group_and_add_event()
    {
        var cmd = Fixture.Create<CreateGroup>();
        var group = new Models.Identity.Group.Group(cmd);
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteGroup>()
            .With(x => x.Id, group.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var sut = new DeleteGroupHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
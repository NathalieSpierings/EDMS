using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Medewerker.CommandHandlers;


[TestFixture]
public class AddMedewerkerToGroupHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMedewerkerRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new MedewerkerRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_add_user_to_group_and_add_event()
    {

        var cmd = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var medewerker = new Models.Betrokkene.Medewerker.Medewerker(cmd);
        var group = new Group
        {
            Id = Guid.NewGuid(),
            Name = "Test group",
            Description = "Test group description"
        };

        _context.Medewerkers.Add(medewerker);
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();

        var gu = new GroupUser
        {
            UserId = medewerker.Id,
            User = medewerker,
            GroupId = group.Id,
            Group = group
        };

        var command = Fixture.Build<AddMedewerkerToGroup>()
            .With(x => x.GroupUser, gu)
            .With(x => x.Id, medewerker.Id)
            .With(x => x.OrganisatieId, medewerker.OrganisatieId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new AddMedewerkerToGroupHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Medewerkers.FirstOrDefaultAsync(x => x.Id == medewerker.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == medewerker.Id);


        Assert.NotNull(dbEntity);

        var groupUser = dbEntity?.Groups.FirstOrDefault(x => x.GroupId == gu.GroupId);
        Assert.AreEqual(gu, groupUser);
        Assert.NotNull(@event);
    }
}
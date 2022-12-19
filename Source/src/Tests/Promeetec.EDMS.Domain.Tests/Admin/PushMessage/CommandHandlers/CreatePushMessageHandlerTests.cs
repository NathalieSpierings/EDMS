using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.PushMessage.CommandHandlers;


[TestFixture]
public class CreatePushMessageHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IPushMessageRepository _repository;
    private IMedewerkerRepository _medewerkerRepository;
    private IGroupRepository _groupRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new PushMessageRepository(_context);
        _medewerkerRepository = new MedewerkerRepository(_context);
        _groupRepository = new GroupRepository(_context);
    }


    [Test]
    public async Task Should_create_new_push_message()
    {
        //var command = Fixture.Build<CreatePushMessage>()
        //    .Without(x => x.Groups)
        //    .With(x => x.Groups, Fixture.Build<Group>()
        //        .Without(x => x.Roles)
        //        .Without(x => x.Users)
        //        .CreateMany().ToList())
        //    .Create();

        var command = Fixture.Build<CreatePushMessage>()
            .Without(x => x.Groups)
            .With(x => x.Groups, Fixture.Build<Group>()
                //.Without(x => x.Roles).With(x => x.Roles, Fixture.Build<GroupRole>().CreateMany().ToList())
                //.Without(x => x.Users).With(x => x.Users, Fixture.Build<GroupUser>().CreateMany().ToList())
                .CreateMany().ToList())
            .Create();


        var sut = new CreatePushMessageHandler(_repository, _medewerkerRepository, _groupRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == command.Id);
        Assert.NotNull(dbEntity);
    }
}
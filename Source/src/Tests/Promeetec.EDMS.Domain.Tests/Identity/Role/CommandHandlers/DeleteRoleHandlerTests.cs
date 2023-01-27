using System.Data;
using AutoFixture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Handlers;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Identity.Role.CommandHandlers;


[TestFixture]
public class DeleteRoleHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IRoleRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        var store = new Mock<IUserStore<Medewerker>>().Object;
        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions
        {
            Lockout =
            {
                AllowedForNewUsers = false
            }
        };
        options.Setup(o => o.Value).Returns(idOptions);

        var userValidators = new List<IUserValidator<Medewerker>>();
        var validator = new Mock<IUserValidator<Medewerker>>();
        userValidators.Add(validator.Object);

        var pwdValidators = new List<PasswordValidator<Medewerker>>
        {
            new PasswordValidator<Medewerker>()
        };

        var userManager = new UserManager<Medewerker>(store, options.Object,
            new PasswordHasher<Medewerker>(), userValidators, pwdValidators,
            new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), null,
            new Mock<ILogger<UserManager<Medewerker>>>().Object);


        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new RoleRepository(_context, userManager);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_role_not_found()
    {
        var sut = new DeleteRoleHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteRole>()));
    }

    [Test]
    public async Task Should_delete_role_and_add_event()
    {
        var cmd = Fixture.Create<CreateRole>();
        var Role = new Models.Identity.Role.Role(cmd);
        _context.Roles.Add(Role);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteRole>()
            .With(x => x.Id, Role.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var sut = new DeleteRoleHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Verwijderd, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
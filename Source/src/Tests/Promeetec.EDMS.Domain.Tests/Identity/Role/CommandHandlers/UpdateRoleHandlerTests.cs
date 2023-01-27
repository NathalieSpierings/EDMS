using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
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
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Identity.Role.CommandHandlers;


[TestFixture]
public class UpdateRoleHandlerTests : TestFixtureBase
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
    public async Task Should_update_role_and_add_event()
    {
        var cmd = Fixture.Build<CreateRole>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var Role = new Models.Identity.Role.Role(cmd);
        _context.Roles.Add(Role);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateRole>()
            .With(x => x.Id, Role.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();


        var validator = new Mock<IValidator<UpdateRole>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateRoleHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Roles.FirstOrDefaultAsync(x => x.Id == Role.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Role.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Name, dbEntity?.Name);
        Assert.NotNull(@event);
    }
}
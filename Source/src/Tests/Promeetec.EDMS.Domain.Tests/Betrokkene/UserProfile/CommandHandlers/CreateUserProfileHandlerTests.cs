using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.UserProfile.CommandHandlers;


[TestFixture]
public class CreateUserProfileHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IUserProfileRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new UserProfileRepository(_context);
    }


    [Test]
    public async Task Should_create_new_user_profile()
    {
        var command = Fixture.Create<CreateUserProfile>();

        var sut = new CreateUserProfileHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
    }
}
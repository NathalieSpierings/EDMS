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
public class UpdatePageSizeHandlerTests : TestFixtureBase
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
    public async Task Should_update_pagesize()
    {
        var cmd = Fixture.Build<CreateUserProfile>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var profile = new Models.Betrokkene.UserProfile.UserProfile(cmd);
        _context.UserProfiles.Add(profile);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdatePageSize>()
            .With(x => x.Id, profile.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new UpdatePageSizeHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == profile.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.PageSize, dbEntity?.PageSize);
    }
}
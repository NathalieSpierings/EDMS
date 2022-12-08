using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Models.Changelog.Handlers;

namespace Promeetec.EDMS.Domain.Tests.Changelog.CommandHandlers;



[TestFixture]
public class UpdateChangelogHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IChangelogRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new ChangelogRepository(_context);
    }

    [Test]
    public async Task Should_update_changelog_post()
    {
        var cmd = Fixture.Build<CreateChangelogPost>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var post = new Models.Changelog.Changelog(cmd);
        _context.Changelogs.Add(post);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateChangelogPost>()
            .With(x => x.Id, post.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();


        var validator = new Mock<IValidator<UpdateChangelogPost>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateChangelogPostHandler(_repository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Changelogs.FirstOrDefaultAsync(x => x.Id == post.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.AreEqual(command.Title, dbEntity.Title);
    }
}
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Changelog.CommandHandlers;



[TestFixture]
public class CreateChangelogHandlerTests : TestFixtureBase
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
    public async Task Should_create_new_changelog_post()
    {
        var command = Fixture.Create<CreateChangelogPost>();

        var validator = new Mock<IValidator<CreateChangelogPost>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateChangelogPostHandler(_repository, validator.Object);

        await sut.Handle(command);

        var dbEntity = await _context.Changelogs.FirstOrDefaultAsync(x => x.Id == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
    }
}
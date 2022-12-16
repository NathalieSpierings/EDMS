using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Models.Changelog.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Changelog.CommandHandlers;



[TestFixture]
public class DeleteChangelogHandlerTests : TestFixtureBase
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
    public void Should_throw_data_exception_when_organisatie_not_found()
    {
        var sut = new DeleteChangelogPostHandler(_repository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteChangelogPost>()));
    }

    [Test]
    public async Task Should_delete_country_and_add_event()
    {
        var cmd = Fixture.Build<CreateChangelogPost>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var post = new Models.Changelog.Changelog(cmd);
        _context.Changelogs.Add(post);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteChangelogPost>()
            .With(x => x.Id, post.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var sut = new DeleteChangelogPostHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Changelogs.FirstOrDefaultAsync(x => x.Id == command.Id);
        Assert.Null(dbEntity);
    }
}
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Mededeling.CommandHandlers;


[TestFixture]
public class UpdateMededelingHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMededelingRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new MededelingRepository(_context);
    }


    [Test]
    public async Task Should_update_mededeling()
    {
        var cmd = Fixture.Create<CreateMededeling>();
        var mededeling = new Models.Admin.Mededeling.Mededeling(cmd);
        _context.Mededelingen.Add(mededeling);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateMededeling>()
            .With(x => x.Id, mededeling.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new UpdateMededelingHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Mededelingen.FirstOrDefaultAsync(x => x.Id == command.Id);
        Assert.NotNull(dbEntity);
    }
}
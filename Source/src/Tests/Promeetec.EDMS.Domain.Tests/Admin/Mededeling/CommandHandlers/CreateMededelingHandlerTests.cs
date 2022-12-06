using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling.Handlers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Mededeling.CommandHandlers;


[TestFixture]
public class CreateMededelingHandlerTests : TestFixtureBase
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
    public async Task Should_create_new_mededeling()
    {
        var command = Fixture.Create<CreateMededeling>();

        var sut = new CreateMededelingHandler(_repository);

        await sut.Handle(command);

        var dbEntity = await _context.Mededelingen.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
    }
}
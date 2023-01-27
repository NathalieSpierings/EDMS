using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Admin.Mededeling.CommandHandlers;


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
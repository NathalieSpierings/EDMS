using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Weegmoment.CommandHandlers;


[TestFixture]
public class CreateWeegmomentHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IWeegmomentRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new WeegmomentRepository(_context);
    }


    [Test]
    public async Task Should_create_new_land_and_add_event()
    {
        var command = Fixture.Create<CreateWeegmoment>();

        var sut = new CreateWeegmomentHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Weegmomenten.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
    }
}
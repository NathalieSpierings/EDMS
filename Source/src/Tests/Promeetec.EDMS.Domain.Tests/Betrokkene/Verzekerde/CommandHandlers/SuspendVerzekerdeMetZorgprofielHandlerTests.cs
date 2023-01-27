using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Handlers;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Verzekerde.CommandHandlers;


[TestFixture]
public class SuspendVerzekerdeMetZorgprofielHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerzekerdeRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new VerzekerdeRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_suspend_verzekerde_with_zorgprofiel_and_add_event()
    {
        var cmd = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                .Without(x => x.Verzekerden)
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var verzekerde = new Models.Betrokkene.Verzekerde.Verzekerde(cmd);
        _context.Verzekerden.Add(verzekerde);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<SuspendVerzekerdeMetZorgprofiel>()
           .With(x => x.Id, verzekerde.Id)
           .With(x => x.OrganisatieId, PromeetecId)
           .With(x => x.UserId, Guid.NewGuid())
           .With(x => x.UserDisplayName, "Ad de Admin")
           .Create();

        var sut = new SuspendVerzekerdeMetZorgprofielHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Verzekerden.FirstOrDefaultAsync(x => x.Id == verzekerde.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == verzekerde.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Inactief, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
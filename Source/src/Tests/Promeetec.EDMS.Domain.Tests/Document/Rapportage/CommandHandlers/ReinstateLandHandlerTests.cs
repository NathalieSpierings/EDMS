using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Land.CommandHandlers;


[TestFixture]
public class ReinstateLandHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private ILandRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new LandRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_reinstate_country_and_add_event()
    {
        var cmd = new CreateLand
        {
            UserId = Guid.NewGuid(),
            UserDisplayName = "Ad de Admin",

            Id = Guid.NewGuid(),
            OrganisatieId = Guid.NewGuid(),

            CultureCode = "nl-NL",
            NativeName = "Nederland"
        };

        var country = new Models.Betrokkene.Land.Land(cmd);
        _context.Landen.Add(country);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ReinstateLand>()
            .With(x => x.Id, country.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ReinstateLandHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == country.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == country.Id);

        Assert.AreEqual(Status.Actief, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Admin.Zorgstraat.CommandHandlers;


[TestFixture]
public class DeleteZorgstraatHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IZorgstraatRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new ZorgstraatRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_zorgstraat_not_found()
    {
        var sut = new DeleteZorgstraatHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteZorgstraat>()));
    }

    [Test]
    public async Task Should_delete_zorgstraat_and_add_event()
    {
        var cmd = new CreateZorgstraat
        {
            UserId = Guid.NewGuid(),
            UserDisplayName = "Ad de Admin",

            Id = Guid.NewGuid(),
            OrganisatieId = PromeetecId,

            Naam = "Test zorgstraat"
        };

        var Zorgstraat = new Models.Admin.Zorgstraat.Zorgstraat(cmd);
        _context.Zorgstraten.Add(Zorgstraat);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<DeleteZorgstraat>()
            .With(x => x.Id, Zorgstraat.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var sut = new DeleteZorgstraatHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Zorgstraten.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
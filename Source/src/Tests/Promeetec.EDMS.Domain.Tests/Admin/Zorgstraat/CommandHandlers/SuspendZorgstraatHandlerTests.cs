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
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Zorgstraat.CommandHandlers;


[TestFixture]
public class SuspendZorgstraatHandlerTests : TestFixtureBase
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
    public async Task Should_suspend_Zorgstraat_and_add_event()
    {
        var cmd = Fixture.Create<CreateZorgstraat>();
        var Zorgstraat = new Models.Admin.Zorgstraat.Zorgstraat(cmd);
        _context.Zorgstraten.Add(Zorgstraat);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<SuspendZorgstraat>()
           .With(x => x.Id, Zorgstraat.Id)
           .With(x => x.OrganisatieId, PromeetecId)
           .With(x => x.UserId, Guid.NewGuid())
           .With(x => x.UserDisplayName, "Ad de Admin")
           .Create();


        var sut = new SuspendZorgstraatHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Zorgstraten.FirstOrDefaultAsync(x => x.Id == Zorgstraat.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Zorgstraat.Id);

        Assert.AreEqual(Status.Inactief, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
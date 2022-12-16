using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Verbruiksmiddelen.CommandHandlers;


[TestFixture]
public class ProcessVerbruiksmiddelPrestatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerbruiksmiddelPrestatieRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new VerbruiksmiddelPrestatieRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_process_presatie_and_add_event()
    {
        var cmd = Fixture.Build<CreateVerbruiksmiddelPrestatie>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var prestatie = new VerbruiksmiddelPrestatie(cmd);
        _context.VerbruiksmiddelPrestaties.Add(prestatie);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ProcessVerbruiksmiddelPrestatie>()
            .With(x => x.Id, prestatie.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ProcessVerbruiksmiddelPrestatieHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.VerbruiksmiddelPrestaties.FirstOrDefaultAsync(x => x.Id == prestatie.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);
        
        Assert.NotNull(dbEntity);
        Assert.AreEqual(VerbruiksmiddelPrestatieStatus.Verwerkt, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
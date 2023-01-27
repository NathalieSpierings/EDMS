using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Declaratie.Aanlevering.CommandHandlers;


[TestFixture]
public class DeleteAanleveringHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IAanleveringRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new AanleveringRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_aanlevering_not_found()
    {
        var sut = new DeleteAanleveringHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteAanlevering>()));
    }

    [Test]
    public async Task Should_delete_aanlevering_and_add_event()
    {
        var cmd = Fixture.Build<CreateAanlevering>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var aanlevering = new Models.Modules.Declaratie.Aanlevering.Aanlevering(cmd);
        _context.Aanleveringen.Add(aanlevering);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteAanlevering>()
            .With(x => x.Id, aanlevering.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new DeleteAanleveringHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Aanleveringen.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Verwijderd, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
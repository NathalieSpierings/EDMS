using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Handlers;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Haarwerk.CommandHandlers;


[TestFixture]
public class CreditHaarwerkHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IHaarwerkRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new HaarwerkRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_credit_presatie_and_add_event()
    {
        var cmd = Fixture.Build<CreateHaarwerk>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var prestatie = new Models.Modules.Haarwerk.Haarwerk(cmd);
        _context.Haarwerk.Add(prestatie);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<CreditHaarwerk>()
            .With(x => x.Id, prestatie.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
        .Create();
        
        var sut = new CreditHaarwerkHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Haarwerk.FirstOrDefaultAsync(x => x.Id == prestatie.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);
        
        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Bsn, dbEntity?.Bsn);
        Assert.NotNull(@event);
    }
}
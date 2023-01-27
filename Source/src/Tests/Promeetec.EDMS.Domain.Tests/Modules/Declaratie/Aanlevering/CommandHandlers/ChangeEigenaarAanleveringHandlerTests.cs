using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Declaratie.Aanlevering.CommandHandlers;


[TestFixture]
public class ChangeEigenaarAanleveringHandlerTests : TestFixtureBase
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
    public async Task Should_update_Aanlevering_and_add_event()
    {
        var cmd = Fixture.Build<CreateAanlevering>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var Aanlevering = new Models.Modules.Declaratie.Aanlevering.Aanlevering(cmd);
        _context.Aanleveringen.Add(Aanlevering);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateAanlevering>()
            .With(x => x.Id, Aanlevering.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateAanlevering>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateAanleveringHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Aanleveringen.FirstOrDefaultAsync(x => x.Id == Aanlevering.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Aanlevering.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.EigenaarId, dbEntity?.EigenaarId);
        Assert.NotNull(@event);
    }
}
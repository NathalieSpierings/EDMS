using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk.Handlers;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.Haarwerk.CommandHandlers;


[TestFixture]
public class UpdateHaarwerkHandlerTests : TestFixtureBase
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
    public async Task Should_update_prestatie()
    {
        var cmd = Fixture.Build<CreateHaarwerk>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var prestatie = new Models.Modules.Haarwerk.Haarwerk(cmd);
        _context.Haarwerk.Add(prestatie);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateHaarwerk>()
            .With(x => x.Id, prestatie.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateHaarwerk>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateHaarwerkHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Haarwerk.FirstOrDefaultAsync(x => x.Id == prestatie.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Bsn, dbEntity?.Bsn);
        Assert.NotNull(@event);
    }
}
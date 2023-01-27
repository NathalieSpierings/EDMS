using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Handlers;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Document.Bestand.CommandHandlers;


[TestFixture]
public class UpdateBestandHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IBestandRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new BestandRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_update_bestand_and_add_event()
    {
        var cmd = Fixture.Build<CreateBestand>().With(x => x.OrganisatieId, Guid.NewGuid).Create();
        var bestand = new Models.Document.Bestand.Bestand(cmd);
        _context.Bestanden.Add(bestand);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<UpdateBestand>()
            .With(x => x.Id, bestand.Id)
            .With(x => x.OrganisatieId, cmd.OrganisatieId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var validator = new Mock<IValidator<UpdateBestand>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateBestandHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Bestanden.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.FileName, dbEntity?.FileName);
        Assert.NotNull(@event);
    }
}
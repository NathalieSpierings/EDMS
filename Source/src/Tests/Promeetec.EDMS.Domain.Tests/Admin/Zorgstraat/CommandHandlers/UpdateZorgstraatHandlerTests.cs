using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Handlers;
using Promeetec.EDMS.Domain.Models.Event;

namespace Promeetec.EDMS.Domain.Tests.Admin.Zorgstraat.CommandHandlers;


[TestFixture]
public class UpdateZorgstraatHandlerTests : TestFixtureBase
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
    public async Task Should_update_Zorgstraat_and_add_event()
    {
        var cmd = Fixture.Create<CreateZorgstraat>();
        var Zorgstraat = new Models.Admin.Zorgstraat.Zorgstraat(cmd);
        _context.Zorgstraten.Add(Zorgstraat);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateZorgstraat>()
            .With(x => x.Id, Zorgstraat.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateZorgstraat>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateZorgstraatHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Zorgstraten.FirstOrDefaultAsync(x => x.Id == Zorgstraat.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == Zorgstraat.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.AreEqual(command.Naam, dbEntity.Naam);
        Assert.NotNull(@event);
    }
}
using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Land.CommandHandlers;


[TestFixture]
public class UpdateLandHandlerTests : TestFixtureBase
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
    public async Task Should_update_land_and_add_event()
    {
<<<<<<< HEAD
        var cmd = Fixture.Create<CreateLand>();
=======
        var cmd = Fixture.Build<CreateLand>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

>>>>>>> 00d8b6b82bfb9370a94aceef6da6c0a6617b3c34
        var land = new Models.Betrokkene.Land.Land(cmd);
        _context.Landen.Add(land);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateLand>()
            .With(x => x.Id, land.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .With(x => x.CultureCode, "en-EN")
            .Create();


        var validator = new Mock<IValidator<UpdateLand>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateLandHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == land.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == land.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.CultureCode, dbEntity.CultureCode);
        Assert.NotNull(@event);
    }
}
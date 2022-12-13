using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers;
using Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekerde.CommandHandlers;


[TestFixture]
public class CreateVerzekerdeHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerzekerdeRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new VerzekerdeRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_verzekerde_and_add_event()
    {
        var command = Fixture.Build<CreateVerzekerde>()
                .Without(x => x.Adres)
                .With(x => x.Adres, Fixture.Build<Adres>()
                    .Without(x => x.Verzekerden)
                    .Without(x => x.Land)
                    .With(x => x.LandId, Guid.NewGuid())
                    .Create())
                .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                    .Without(x => x.Verzekerden)
                    .Create())
                .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                    .Without(x => x.Verzekerden)
                    .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                        .With(x => x.Id, Guid.NewGuid())
                        .Create())
                    .Create())
                .Create();

        var validator = new Mock<IValidator<CreateVerzekerde>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateVerzekerdeHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Verzekerden.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
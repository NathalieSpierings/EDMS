using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Handlers;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Declaratie.Aanleverbericht.CommandHandlers;

[TestFixture]
public class CreateAanleverberichtHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IAanleveringRepository _aanleveringRepository;
    private IAanleverberichtRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _aanleveringRepository = new AanleveringRepository(_context);
        _repository = new AanleverberichtRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public async Task Should_create_new_aanleverbericht_and_add_event()
    {
        var cmd = Fixture.Build<CreateAanlevering>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var aanlevering = new Models.Modules.Declaratie.Aanlevering.Aanlevering(cmd);
        _context.Aanleveringen.Add(aanlevering);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<CreateAanleverbericht>()
            .With(x => x.AanleveringId, aanlevering.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var validator = new Mock<IValidator<CreateAanleverbericht>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new CreateAanleverberichtHandler(_repository, _aanleveringRepository, _eventRepository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.Aanleverberichten.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.NotNull(dbEntity);
        Assert.NotNull(@event);
    }
}
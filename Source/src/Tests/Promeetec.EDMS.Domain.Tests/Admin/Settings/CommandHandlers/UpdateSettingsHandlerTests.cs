using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.Settings;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Settings.CommandHandlers;


[TestFixture]
public class UpdateSettingsHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private ISettingsRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new SettingsRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_update_setting_and_add_event()
    {
        var settings = new Models.Admin.Settings.Settings
        {
            Straat = "New street",
            Huisnummer = "55",
            Huisnummertoevoeging = "A",
            Postcode = "1011DB",
            Woonplaats = "Broekland",
            Telefoon = "0401234567",
            Email = "info@test.nl",
            Haarwerk = new SettingsHaarwerk
            {
                BedragBasisVerzekeringHaarwerk = new decimal(12.25)
            }
        };
        _context.Settings.Add(settings);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateSettings>()
            .With(x => x.Id, settings.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var validator = new Mock<IValidator<UpdateSettings>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateSettingsHandler(_repository, _eventRepository, validator.Object);
        await sut.Handle(command);


        var dbEntity = await _context.Settings.FirstOrDefaultAsync(x => x.Id == settings.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == settings.Id);


        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.Straat, dbEntity?.Straat);
        Assert.NotNull(@event);
    }
}
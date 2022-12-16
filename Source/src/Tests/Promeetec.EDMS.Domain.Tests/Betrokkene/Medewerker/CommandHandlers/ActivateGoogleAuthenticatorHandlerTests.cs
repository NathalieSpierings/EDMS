using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Medewerker.CommandHandlers;


[TestFixture]
public class ActivateGoogleAuthenticatorHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IMedewerkerRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new MedewerkerRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_activate_google_authenticator_and_add_event()
    {
        var cmd = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var medewerker = new Models.Betrokkene.Medewerker.Medewerker(cmd);
        _context.Medewerkers.Add(medewerker);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ActivateGoogleAuthenticator>()
            .With(x => x.Id, medewerker.Id)
            .With(x => x.OrganisatieId, medewerker.OrganisatieId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .With(x => x.AccountState, UserAccountState.GoogleAuthenticatorAcivated)
            .With(x => x.SecretKey, "SecretKey")
            .Create();

        var sut = new ActivateGoogleAuthenticatorHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Medewerkers.FirstOrDefaultAsync(x => x.Id == medewerker.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == medewerker.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(UserAccountState.GoogleAuthenticatorAcivated, dbEntity?.AccountState);
        Assert.AreEqual(true, dbEntity?.GoogleAuthenticatorEnabled);
        Assert.AreEqual("SecretKey", dbEntity?.GoogleAuthenticatorSecretKey);
        Assert.AreEqual(true, dbEntity?.TwoFactorEnabled);
        Assert.NotNull(@event);
    }
}
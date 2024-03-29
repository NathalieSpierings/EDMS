﻿using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Handlers;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Organisatie.CommandHandlers;


[TestFixture]
public class ReinstateOrganisatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IOrganisatieRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());

        _repository = new OrganisatieRepository(_context);
        _eventRepository = new EventRepository(_context);
    }

    [Test]
    public async Task Should_reinstate_organisatie_and_add_event()
    {
        var cmd = new CreateOrganisatie
        {
            Id = Guid.NewGuid(),
            Nummer = "1234",
            Naam = "Test org 1",
            TelefoonZakelijk = "1234567897",
            TelefoonPrive = "7894561236",
            Email = "email@test.com",
            Website = "http://www.test.com",
            AgbCodeOnderneming = "12345678",
            Zorggroep = false,
            Logo = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw=="),
            Settings = new OrganisatieSettings
            {
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);

        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<ReinstateOrganisatie>()
            .With(x => x.Id, organisatie.Id)
            .With(x => x.OrganisatieId, organisatie.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new ReinstateOrganisatieHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Organisaties.FirstOrDefaultAsync(x => x.Id == organisatie.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == organisatie.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Actief, dbEntity?.Status);
        Assert.NotNull(@event);
    }
}
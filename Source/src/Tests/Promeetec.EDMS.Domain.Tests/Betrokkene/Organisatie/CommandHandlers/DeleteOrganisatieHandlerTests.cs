using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Organisatie.CommandHandlers;


[TestFixture]
public class DeleteOrganisatieHandlerTests : TestFixtureBase
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
    public void Should_throw_data_exception_when_organisatie_not_found()
    {
        var sut = new DeleteOrganisatieHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteOrganisatie>()));
    }

    [Test]
    public async Task Should_delete_organisatie_and_add_event()
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

        var organisatie1 = new Models.Betrokkene.Organisatie.Organisatie(cmd);

        _context.Organisaties.Add(organisatie1);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteOrganisatie>()
            .With(x => x.Id, organisatie1.Id)
            .With(x => x.OrganisatieId, organisatie1.Id)
            .Create();

        var sut = new DeleteOrganisatieHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Organisaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, dbEntity.Status);
        Assert.NotNull(@event);
    }
}
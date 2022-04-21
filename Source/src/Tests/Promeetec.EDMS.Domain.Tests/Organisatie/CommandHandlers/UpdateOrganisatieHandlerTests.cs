using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Handlers;
using Promeetec.EDMS.Domain.Models.Cov;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.ION;

namespace Promeetec.EDMS.Domain.Tests.Organisatie.CommandHandlers;


[TestFixture]
public class UpdateOrganisatieHandlerTests : TestFixtureBase
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
    public async Task Should_update_organisatie_and_add_event()
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
                IONZoekoptie = IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners,
                AanleverbestandLocatie = "Test location",
                AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.InBehandeling,
                COVControleProcessType = COVControleProcessType.COVProcesDoorzettenBijUitval,
                COVControleType = COVControleType.COVControleBijAanlevering,
                VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerVerplicht
            },
            ContactpersoonId = Guid.NewGuid(),
            ZorggroepRelatieId = Guid.NewGuid(),
            VoorraadId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            AdresId = Guid.NewGuid()
        };

        var organisatie = new Models.Betrokkene.Organisatie.Organisatie(cmd);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<UpdateOrganisatie>()
            .With(x => x.Id, organisatie.Id)
            .With(x => x.OrganisatieId, organisatie.Id)
            .Create();

        var validator = new Mock<IValidator<UpdateOrganisatie>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateOrganisatieHandler(_repository, _eventRepository, validator.Object);

        await sut.Handle(command);


        var updatedOrganisatie = await _context.Organisaties.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        Assert.AreEqual(command.Naam, updatedOrganisatie.Naam);
        Assert.NotNull(@event);
    }
}
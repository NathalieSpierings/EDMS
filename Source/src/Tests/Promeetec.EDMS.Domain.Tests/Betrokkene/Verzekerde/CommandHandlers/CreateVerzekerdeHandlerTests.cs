using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
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



        var command = new CreateVerzekerde
        {
            UserId = Guid.NewGuid(),
            UserDisplayName = "Ad de Admin",

            Id = Guid.NewGuid(),
            OrganisatieId = Guid.NewGuid(),
            AdresboekId = Guid.NewGuid(),
            Bsn = "054243579",
            Persoon = new Persoon
            {
                Geboortedatum = new DateTime(1975, 07, 22),
                Geslacht = Geslacht.Vrouwelijk,
                Voorletters = "J",
                Voornaam = "Joan",
                Achternaam = "Do",
                TelefoonZakelijk = "1234567897",
                TelefoonPrive = "7894561236",
                Email = "joan.do@test.com",
            },
            Adres = new Adres
            {
                Straat = "Koeveringsedijk",
                Huisnummer = "5",
                Huisnummertoevoeging = "A",
                Postcode = "5491SB",
                Woonplaats = "Sint Oedenrode",
                LandNaam = "NEDERLAND"
            },
            Zorgverzekering = new Zorgverzekering
            {
                Id = Guid.NewGuid(),
                PatientNummer = "154545",
                VerzekerdeNummer = "987965",
                VerzekeraarId = Guid.NewGuid(),
                VerzekerdOp = DateTime.Now.AddYears(-10),
                Verzekeraar = new Models.Betrokkene.Verzekeraar.Verzekeraar
                {
                    Id = Guid.NewGuid(),
                    Uzovi = 5421,
                    Naam = "Unilever",
                    Actief = true
                }
            },
            Zorgprofiel = new Zorgprofiel
            {
                ProfielCode = ProfielCode.ProfielCode4,
                ProfielStartdatum = DateTime.Now.AddYears(-2),
                ProfielEinddatum = null,
                TimeStamp = DateTime.Now
            },
            AgbCodeVerwijzer = "87654321",
            NaamVerwijzer = "Henk de Vries",
            Verwijsdatum = DateTime.Now.AddYears(-1)
        };
        
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
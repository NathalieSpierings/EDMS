using AutoFixture;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Mapping;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Reporting.Tests.Private.Betrokkene;

[TestFixture]
public class OrganisatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IOrganisatieRepository _repository;


   [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(EDMS.Tests.Helpers.Shared.CreateContextOptions());
        _repository = new OrganisatieRepository(_context);
    }


    [Test]
    public async Task Should_get_result()
    {
        var query = new GetOrganisatie();
        var result = new OrganisatieModel();

        var commandSender = new Mock<ICommandSender>();

        var queryProcessor = new Mock<IQueryProcessor>();
        queryProcessor.Setup(x => x.Process(query)).ReturnsAsync(result);

        var eventPublisher = new Mock<IEventPublisher>();
        var objectFactory = new Mock<IObjectFactory>();

        var sut = new Dispatcher(commandSender.Object, queryProcessor.Object, eventPublisher.Object, objectFactory.Object);

        var actual = await sut.Get(query);

        queryProcessor.Verify(x => x.Process(query), Times.Once);
        Assert.AreEqual(result, actual);
    }



    [Test]
    public async Task Should_return_organisatie()
    {
        var cmdContactpersson = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();


        var medewerker = new Medewerker(cmdContactpersson);
        _context.Medewerkers.Add(medewerker);
        await _context.SaveChangesAsync();

        var cmdOrganisatie = Fixture.Build<CreateOrganisatie>().With(x => x.ContactpersoonId, medewerker.Id).Create();
        var organisatie = new Organisatie(cmdOrganisatie);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        var query = new GetOrganisatie { OrganisatieId = organisatie.Id, IncludeGekoppeldeOrganisaties = false };
        var dispatcher = new Dispatcher(new Mock<ICommandSender>().Object, new Mock<IQueryProcessor>().Object, new Mock<IEventPublisher>().Object, new Mock<IObjectFactory>().Object);
        var sut = new GetOrganisatieHandler(dispatcher, _repository);
        var actual = await sut.Handle(query);
        Assert.NotNull(actual);
    }
}

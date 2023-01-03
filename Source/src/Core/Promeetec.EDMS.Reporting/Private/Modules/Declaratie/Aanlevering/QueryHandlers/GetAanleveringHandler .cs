using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Queries;
using Promeetec.EDMS.Reporting.Document.Aanleverbestand.Queries;
using Promeetec.EDMS.Reporting.Document.Overigbestand.Queries;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Aanleverbericht.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;

public class GetAanleveringHandler : IQueryHandlerAsync<GetAanlevering, AanleveringViewModel>
{
    private readonly IAanleveringRepository _repository;
    private readonly IDispatcher _dispatcher;

    private readonly IMedewerkerRepository _medewerkerRepository;

    public GetAanleveringHandler(IDispatcher dispatcher, IAanleveringRepository repository, IMedewerkerRepository medewerkerRepository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<AanleveringViewModel> HandleAsync(GetAanlevering query)
    {
        var model = await _repository
            .Query()
            .AsNoTracking()
            .Include(i => i.Aanleverberichten)
            .Where(x => query.OrganisatieId != null ? x.Id == query.AanleveringId &&
                                                      x.OrganisatieId == query.OrganisatieId &&
                                                      x.Status != Status.Verwijderd :
                x.Id == query.AanleveringId &&
                x.Status != Status.Verwijderd)

            .Select(x => new AanleveringViewModel
            {
                Id = x.Id,
                Referentie = x.Referentie,
                ReferentiePromeetec = x.ReferentiePromeetec,
                ToevoegenBestand = x.ToevoegenBestand,
                AanleverStatus = x.AanleverStatus,
                Status = x.Status,
                Opmerking = x.Opmerking,
                Jaar = x.Jaar,
                Organisatie = new OrganisatieViewModel
                {
                    Id = x.OrganisatieId,
                    Nummer = x.Organisatie.Nummer,
                    Naam = x.Organisatie.Naam,
                    ContactpersoonId = x.Organisatie.ContactpersoonId,
                },
                Eigenaar = new MedewerkerViewModel
                {
                    Id = x.EigenaarId
                },
                BehandelaarId = x.BehandelaarId,
                Behandelaar = new MedewerkerViewModel
                {
                    Id = x.BehandelaarId.Value
                },
                Aanleverdatum = x.Aanleverdatum,
                AangemaaktDoorId = x.AangemaaktDoor,
                AangepastOp = x.AangepastOp,
                AangepastDoorId = x.AangepastDoor
            }).FirstOrDefaultAsync();

        model.AangemaaktDoor = model.AangemaaktDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangemaaktDoorId.Value) : string.Empty;
        model.AangepastDoor = model.AangepastDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangepastDoorId.Value) : string.Empty;


        model.Organisatie = await _dispatcher.GetResultAsync(new GetOrganisatie
        {
            OrganisatieId = model.Organisatie.Id
        });

        model.Eigenaar = await _dispatcher.GetResultAsync(new GetMedewerker
        {
            MedewerkerId = model.Eigenaar.Id,
            IncludeProfile = true
        });

        model.Behandelaar = await _dispatcher.GetResultAsync(new GetMedewerker
        {
            MedewerkerId = model.Behandelaar.Id,
            IncludeProfile = true
        });

        model.AantalBerichten = await _dispatcher.GetResultAsync(new GetAantalAanleverberichten
        {
            AanleveringId = query.AanleveringId
        });


        if (query.IncludeBestanden)
        {
            // Get aanleverbestanden
            model.Aanleverbestanden = await _dispatcher.GetResultAsync(new GetAanleverbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId
            });

            // Get overigebestanden
            model.Overigebestanden = await _dispatcher.GetResultAsync(new GetOverigbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId
            });
        }

        return model;
    }
}
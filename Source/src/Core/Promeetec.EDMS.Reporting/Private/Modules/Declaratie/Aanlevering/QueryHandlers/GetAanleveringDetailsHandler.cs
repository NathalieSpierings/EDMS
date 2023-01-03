using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;

public class GetAanleveringDetailsHandler : IQueryHandlerAsync<GetAanleveringDetails, AanleveringDetailsViewModel>
{
    private readonly IAanleveringRepository _repository;
    private readonly IMedewerkerRepository _medewerkerRepository;


    public GetAanleveringDetailsHandler(IAanleveringRepository repository, IMedewerkerRepository medewerkerRepository)
    {
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
    }

    public async Task<AanleveringDetailsViewModel> HandleAsync(GetAanleveringDetails query)
    {
        var model = await _repository.Query()
            .Where(x => x.Id == query.AanleveringId && x.OrganisatieId == query.OrganisatieId)
            .Select(x => new AanleveringDetailsViewModel
            {
                Id = x.Id,
                Jaar = x.Jaar,
                Referentie = x.Referentie,
                ReferentiePromeetec = x.ReferentiePromeetec,
                Opmerking = x.Opmerking,
                ToevoegenBestand = x.ToevoegenBestand,
                AanleverStatus = x.AanleverStatus,
                Status = x.Status,
                Aanleverdatum = x.Aanleverdatum,
                AangemaaktDoorId = x.AangemaaktDoor,
                AangepastOp = x.AangepastOp,
                AangepastDoorId = x.AangepastDoor,
                EigenaarId = x.EigenaarId,
                EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                BehandelaarId = x.BehandelaarId,
                BehandelaarVolledigeNaam = x.Behandelaar.Persoon.VolledigeNaam,
                Organisatie = new OrganisatieViewModel
                {
                    Id = x.OrganisatieId,
                    Nummer = x.Organisatie.Nummer,
                    Naam = x.Organisatie.Naam
                }
            })
            .FirstOrDefaultAsync();

        model.AangemaaktDoor = model.AangemaaktDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangemaaktDoorId.Value) : string.Empty;
        model.AangepastDoor = model.AangepastDoorId.HasValue ? await _medewerkerRepository.GetVolledigeNaamByIdAsync(model.AangepastDoorId.Value) : string.Empty;

        return model;
    }
}
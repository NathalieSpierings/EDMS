using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Queries;
using Promeetec.EDMS.Reporting.Document.Aanleverbestand.Queries;
using Promeetec.EDMS.Reporting.Document.Overigbestand.Queries;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Aanleverbericht.Queries;
using Promeetec.EDMS.Reporting.Private.Document;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;

public class GetAanleveringCreateHandler : IQueryHandlerAsync<GetAanleveringCreate, AanleveringCreateViewModel>
{
    private readonly IAanleveringRepository _repository;
    private readonly IDispatcher _dispatcher;

    public GetAanleveringCreateHandler(IDispatcher dispatcher, IAanleveringRepository repository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
    }

    public async Task<AanleveringCreateViewModel> HandleAsync(GetAanleveringCreate query)
    {
        var model = new AanleveringCreateViewModel();

        if (query.OrganisatieId != null)
        {
            model = await _repository.Query()
                .Include(i => i.Aanleverberichten)
                .Where(x => x.Id == query.AanleveringId && x.OrganisatieId == query.OrganisatieId && x.Status != Status.Verwijderd)
                .Select(x => new AanleveringCreateViewModel
                {
                    Id = x.Id,
                    Jaar = x.Jaar,
                    Referentie = x.Referentie,
                    ReferentiePromeetec = x.ReferentiePromeetec,
                    ToevoegenBestand = x.ToevoegenBestand,
                    Opmerking = x.Opmerking,
                    AanleverStatus = x.AanleverStatus,
                    Aanleverdatum = x.Aanleverdatum,
                    AangemaaktDoor = x.AangemaaktDoor,
                    AangepastOp = x.AangepastOp,
                    AangepastDoor = x.AangepastDoor,
                    Status = x.Status,
                    BehandelaarId = x.BehandelaarId,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                        ContactpersoonId = x.Organisatie.ContactpersoonId,
                        ContactpersoonVolledigeNaam = x.Organisatie.Contactpersoon.Persoon.VolledigeNaam
                    },
                    EigenaarId = x.EigenaarId,
                    Files = new FilesViewModel
                    {
                        OrganisatieId = x.OrganisatieId,
                        AanleveringId = x.Id,
                        UploadType = UploadType.Overigbestand
                    },
                    OudeAanleverStatus = x.AanleverStatus
                })
                .FirstOrDefaultAsync();
        }
        else
        {
            model = await _repository.Query()
                .Include(i => i.Aanleverberichten)
                .Where(x => x.Id == query.AanleveringId && x.Status != Status.Verwijderd)
                .Select(x => new AanleveringCreateViewModel
                {
                    Id = x.Id,
                    Jaar = x.Jaar,
                    Referentie = x.Referentie,
                    ReferentiePromeetec = x.ReferentiePromeetec,
                    ToevoegenBestand = x.ToevoegenBestand,
                    Opmerking = x.Opmerking,
                    AanleverStatus = x.AanleverStatus,
                    Aanleverdatum = x.Aanleverdatum,
                    AangemaaktDoor = x.AangemaaktDoor,
                    AangepastOp = x.AangepastOp,
                    AangepastDoor = x.AangepastDoor,
                    Status = x.Status,
                    BehandelaarId = x.BehandelaarId,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                        ContactpersoonId = x.Organisatie.Contactpersoon.Id,
                        ContactpersoonVolledigeNaam = x.Organisatie.Contactpersoon.Persoon.VolledigeNaam
                    },
                    EigenaarId = x.EigenaarId
                })
                .FirstOrDefaultAsync();
        }

        if (model == null)
            return model;

        model.Organisatie = await _dispatcher.GetResultAsync(new GetOrganisatie
        {
            OrganisatieId = model.Organisatie.Id
        });

        model.Eigenaar = await _dispatcher.GetResultAsync(new GetMedewerker
        {
            MedewerkerId = model.EigenaarId,
            IncludeProfile = true
        });
        model.AanleverstatusIds = model.Eigenaar.UserProfile.AanleverstatusIds;


        model.AantalBerichten = await _dispatcher.GetResultAsync(new GetAantalAanleverberichten
        {
            AanleveringId = query.AanleveringId
        });


        if (query.IncludeAanleverbestanden)
        {
            model.Aanleverbestanden = await _dispatcher.GetResultAsync(new GetAanleverbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId
            });
        }

        if (query.IncludeOverigebestanden)
        {
            model.Overigebestanden = await _dispatcher.GetResultAsync(new GetOverigbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId
            });
        }

        return model;
    }
}
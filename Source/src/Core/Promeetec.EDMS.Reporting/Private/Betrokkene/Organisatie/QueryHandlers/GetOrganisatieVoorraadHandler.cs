using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieVoorraadHandler : IQueryHandlerAsync<GetOrganisatieVoorraad, OrganisatieVoorraadViewModel>
{
    private readonly IOrganisatieRepository _organisatieRepository;
    private readonly IAanleverbestandRepository _repository;

    public GetOrganisatieVoorraadHandler(IAanleverbestandRepository repository, IOrganisatieRepository organisatieRepository)
    {
        _repository = repository;
        _organisatieRepository = organisatieRepository;
    }

    public async Task<OrganisatieVoorraadViewModel> HandleAsync(GetOrganisatieVoorraad query)
    {
        var organisatie = await _organisatieRepository.FirstOrDefaultAsync(query.OrganisatieId);

        var model = new OrganisatieVoorraadViewModel
        {
            Organisatie = new OrganisatieViewModel
            {
                Id = query.OrganisatieId,
                VoorraadId = organisatie.Voorraad.Id,
                Nummer = organisatie.Nummer,
                Naam = organisatie.Naam,
                Zorggroep = organisatie.Zorggroep
            }
        };


        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.VoorraadId == organisatie.Voorraad.Id && x.WorkFlowState == AanleverbestandWorkflowState.Voorraad);


        if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
        {
            // Alleen bestanden van de eigenaar mogen getoond worden
            dbQuery = dbQuery.Where(x => x.EigenaarId == query.User.Id);
        }


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var aangemaaktOp))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.AangemaaktOp) == aangemaaktOp);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.FileName.Contains(match) ||
                                                 x.Eigenaar.Persoon.FormeleNaam.Contains(match) ||
                                                 x.Zorgstraat.Naam.Contains(match) ||
                                                 x.Periode.Contains(match));
                }
            }
        }


        model.Voorraadbestanden = dbQuery.OrderBy(o => o.AangemaaktOp).Select(x => new OrganisatieVoorraadListItemViewModel
        {
            Id = x.Id,
            OrganisatieId = query.OrganisatieId,
            Extension = x.Extension,
            FileName = x.FileName,
            EigenaarId = x.EigenaarId,
            EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
            ZorgstraatNaam = x.Zorgstraat.Naam,
            Periode = x.Periode,
            Gecontroleerd = x.Gecontroleerd,
            AangemaaktOp = x.AangemaaktOp
        });

        return model;
    }
}
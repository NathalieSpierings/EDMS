using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;


public class GetAanleveringenHandler : IQueryHandlerAsync<GetAanleveringen, AanleveringenViewModel>
{
    private readonly IAanleveringRepository _repository;
    private readonly IOrganisatieRepository _organisatieRepository;


    public GetAanleveringenHandler(IAanleveringRepository repository, IOrganisatieRepository organisatieRepository)
    {
        _repository = repository;
        _organisatieRepository = organisatieRepository;
    }

    public async Task<AanleveringenViewModel> HandleAsync(GetAanleveringen query)
    {
        await Task.CompletedTask;

        var model = new AanleveringenViewModel
        {
            Organisatie = new OrganisatieViewModel
            {
                Id = query.OrganisatieId ?? Guid.Empty
            }
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Aanleverberichten)
            .Include(i => i.Aanleverbestanden)
            .Include(i => i.Overigebestanden)
            .Include(i => i.Organisatie)
            .Include(i => i.Eigenaar);

        if (!query.IncludeDeletes)
            dbQuery = dbQuery.Where(x => x.Status != Status.Verwijderd);


        if (query.OrganisatieId != null && query.OrganisatieId != Guid.Empty)
        {
            // Retrieve all aanleveringen for given organization
            dbQuery = dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId);

            // Retrieve all aanleveringen for given organization and practitioner. (Only for internal employees)
            if (query.BehandelaarId != Guid.Empty && query.BehandelaarId != null)
            {
                dbQuery = dbQuery.Where(x => x.BehandelaarId == query.BehandelaarId || x.Organisatie.ContactpersoonId == query.BehandelaarId);
            }
            else
            {
                // Retrieve all aanleveringen for given organization with own aanleverbestanden
                if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
                    dbQuery = dbQuery.Where(x => x.Aanleverbestanden.Any(b => b.EigenaarId == query.User.Id));
            }

            // Complete the viewmodel with the organization details
            var organisatie = dbQuery.Any()
                ? dbQuery.FirstOrDefault().Organisatie
                : await _organisatieRepository.GetOrganisatieByIdAsync(query.OrganisatieId.Value);

            model.Organisatie = new OrganisatieViewModel
            {
                VoorraadId = organisatie.Voorraad.Id,
                Nummer = organisatie.Nummer,
                Naam = organisatie.Naam
            };
        }
        else if (query.BehandelaarId != null && query.BehandelaarId != Guid.Empty)
        {
            // Retrieve all aanleveringen for given practitioner
            dbQuery = dbQuery.Where(x => x.BehandelaarId == query.BehandelaarId || x.Organisatie.ContactpersoonId == query.BehandelaarId);
        }


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var aanleverDatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.Aanleverdatum) == aanleverDatum);
                }
                else if (DateTime.TryParse(match, out var aangepastOpDate))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.AangepastOp.Value) == aangepastOpDate);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Organisatie.Nummer.Contains(match) ||
                                                 x.Organisatie.Naam.Contains(match) ||
                                                 x.Organisatie.Contactpersoon.Persoon.FormeleNaam.Contains(match) ||
                                                 x.Referentie.Contains(match) ||
                                                 x.ReferentiePromeetec.Contains(match) ||
                                                 x.AanleverStatus.ToString().Contains(match));
                }
            }
        }

        model.Aanleveringen = dbQuery.Select(x => new AanleveringListItemViewModel
        {
            Id = x.Id,
            AantalBerichten = x.Aanleverberichten.Count(b => b.ParentId == null),
            AantalAanleverbestanden = x.Aanleverbestanden.Count,
            AantalOverigebestanden = x.Overigebestanden.Count,
            OrganisatieId = x.OrganisatieId,
            OrganisatieNaam = x.Organisatie.Naam,
            Referentie = x.Referentie,
            ReferentiePromeetec = x.ReferentiePromeetec,
            AanleverStatus = x.AanleverStatus,
            ToevoegenBestand = x.ToevoegenBestand,
            Aanleverdatum = x.Aanleverdatum,
            AangepastOp = x.AangepastOp,
            Opmerking = x.Opmerking,
            Status = x.Status,
            EigenaarId = x.EigenaarId,
            EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
            BehandelaarId = x.BehandelaarId,
            BehandelaarFormeleNaam = x.Behandelaar.Persoon.FormeleNaam,
            BehandelaarOrganisatieId = x.Behandelaar.OrganisatieId
        }).OrderBy(o => o.Aanleverdatum);

        return model;
    }
}
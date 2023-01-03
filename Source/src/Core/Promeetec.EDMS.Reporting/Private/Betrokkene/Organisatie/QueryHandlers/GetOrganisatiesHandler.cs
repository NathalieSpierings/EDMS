using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatiesHandler : IQueryHandlerAsync<GetOrganisaties, OrganisatiesViewModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetOrganisatiesHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganisatiesViewModel> HandleAsync(GetOrganisaties query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking();

        dbQuery = query.IncludeDelete
            ? dbQuery
            : dbQuery.Where(x => x.Status != Status.Verwijderd);

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (match == "geblokkeerd" || match == "beperkt")
                {
                    dbQuery = dbQuery.Where(x => x.Beperkt);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Naam.Contains(match) ||
                                                 x.Nummer.Contains(match) ||
                                                 x.Email.Contains(match) ||
                                                 x.AgbCodeOnderneming.Contains(match) ||
                                                 x.Status.ToString().Trim().Contains(match) ||
                                                 x.Contactpersoon.Persoon.FormeleNaam.Contains(match));
                }
            }
        }

        var model = new OrganisatiesViewModel
        {
            Organisaties = dbQuery.Select(x => new OrganisatieListItemViewModel
            {
                Id = x.Id,
                AdresboekId = x.Adresboek.Id,
                Nummer = x.Nummer,
                Naam = x.Naam,
                AgbCodeOnderneming = x.AgbCodeOnderneming,
                Contactpersoon = x.ContactpersoonId != null && x.ContactpersoonId != Guid.Empty ? new MedewerkerViewModel
                {
                    Id = x.ContactpersoonId.Value,
                    FormeleNaam = x.Contactpersoon.Persoon.FormeleNaam,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.Contactpersoon.Organisatie.Id
                    }
                }
                    : null,
                Status = x.Status,
                Zorggroep = x.Zorggroep,
                Beperkt = x.Beperkt,
                VoorraadId = x.Voorraad.Id,
            }).OrderBy(o => o.Naam)
        };

        return model;
    }
}
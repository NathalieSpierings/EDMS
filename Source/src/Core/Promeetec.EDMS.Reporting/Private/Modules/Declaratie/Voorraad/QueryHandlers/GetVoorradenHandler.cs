using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.QueryHandlers;

public class GetVoorraadHandler : IQueryHandlerAsync<GetVoorraden, VoorradenViewModel>
{
    private readonly IVoorraadRepository _repository;

    public GetVoorraadHandler(IVoorraadRepository repository)
    {
        _repository = repository;
    }

    public async Task<VoorradenViewModel> HandleAsync(GetVoorraden query)
    {
        await Task.CompletedTask;

        var model = new VoorradenViewModel
        {
            Voorraden = new List<VoorraadListItemViewModel>()
        };

        var dbQuery = _repository.Query().AsNoTracking().Where(x => x.Organisatie.Status != Status.Verwijderd);

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Organisatie.Nummer.Contains(match) ||
                                             x.Organisatie.Naam.Contains(match));
            }
        }

        var items = dbQuery.Select(x => new VoorraadListItemViewModel
        {
            Id = x.Id,
            AantalVoorraadbestanden = x.Voorraadbestanden.Count(e => e.AanleveringId == null),
            OrganisatieId = x.Organisatie.Id,
            OrganisatieNummer = x.Organisatie.Nummer,
            OrganisatieNaam = x.Organisatie.Naam
        });

        model.Voorraden = items.OrderBy(o => o.OrganisatieNaam);
        return model;
    }
}
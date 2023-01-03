using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkersHandler : IQueryHandlerAsync<GetMedewerkers, MedewerkersViewModel>
{
    private readonly IMedewerkerRepository _repository;

    public GetMedewerkersHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<MedewerkersViewModel> HandleAsync(GetMedewerkers query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking();

        dbQuery = query.IncludeDelete
            ? dbQuery
            : dbQuery.Where(x => x.Status != Status.Verwijderd);


        if (query.OrganisatieId != null && query.OrganisatieId != Guid.Empty)
        {
            dbQuery = dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId);

        }

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var laatstIngelogdOp))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.LaatstIngelogdOp) == laatstIngelogdOp);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Persoon.FormeleNaam.Contains(match) ||
                                                 x.Persoon.Email.Contains(match) ||
                                                 x.Persoon.Telefoon.Contains(match) ||
                                                 x.Status.ToString().Trim().Contains(match) ||
                                                 x.UserName.Contains(match) ||
                                                 x.Organisatie.Nummer.Contains(match) ||
                                                 x.Organisatie.Naam.Contains(match) ||
                                                 x.AgbCodeOnderneming.Contains(match));
                }
            }
        }

        var model = new MedewerkersViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            Medewerkers = dbQuery.OrderBy(o => o.Persoon.FormeleNaam).Select(x => new MedewerkerListItemViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                LastLoginDate = x.LaatstIngelogdOp,
                Status = x.Status,
                AccountState = x.AccountState,
                FormeleNaam = x.Persoon.FormeleNaam,
                Email = x.Email,
                Telefoon = x.Persoon.Telefoon,
                OrganisatieId = x.OrganisatieId,
                OrganisatieNaam = x.Organisatie.Naam,
                AgbCodeOnderneming = x.AgbCodeOnderneming != null ? string.Concat("[", x.AgbCodeOnderneming.Replace(",", "]-["), "]") : "",
                IsUserAuthorized = x.Groups.Any()
            })
        };

        return model;
    }
}
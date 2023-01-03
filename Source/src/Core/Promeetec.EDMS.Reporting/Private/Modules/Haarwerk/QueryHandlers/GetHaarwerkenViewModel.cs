using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Modules.Haarwerk.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.QueryHandlers;

public class GetHaarwerkenHandler : IQueryHandlerAsync<GetHaarwerken, HaarwerkenViewModel>
{
    private readonly IHaarwerkRepository _repository;

    public GetHaarwerkenHandler(IHaarwerkRepository repository)
    {
        _repository = repository;
    }

    public async Task<HaarwerkenViewModel> HandleAsync(GetHaarwerken query)
    {
        await Task.CompletedTask;

        var model = new HaarwerkenViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Organisatie);

        dbQuery = query.Processed
            ? dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId && x.Status == HaarwerkStatus.Verwerkt)
            : dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId && x.Status == HaarwerkStatus.Nieuw);


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var afleverdatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.Afleverdatum) == afleverdatum);
                }
                else if (DateTime.TryParse(match, out var geboortedatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.Geboortedatum) == geboortedatum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Naam.Contains(match) ||
                                                 x.Bsn.Contains(match) ||
                                                 x.TypeHulpmiddel.ToString().Contains(match) ||
                                                 x.BedragEigenBijdragen.ToString().Contains(match) ||
                                                 x.BedragTeOntvangen.ToString().Contains(match) ||
                                                 x.Status.ToString().Contains(match));
                }
            }
        }

        model.Prestaties = dbQuery.Select(x => new HaarwerkListItemViewModel
        {
            Id = x.Id,
            OrganisatieId = x.OrganisatieId,
            Naam = x.Naam,
            Geboortedatum = x.Geboortedatum,
            Bsn = x.Bsn,
            TypeHulpmiddel = x.TypeHulpmiddel,
            Afleverdatum = x.Afleverdatum,
            EigenBijdrage = x.BedragEigenBijdragen,
            BedragTeOntvangen = x.BedragTeOntvangen,
            Status = x.Status,
            CreditType = x.CreditType
        });

        return model;
    }
}
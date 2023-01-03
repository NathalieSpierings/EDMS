using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.QueryHandlers;

public class GetRedenenEindeZorgHandler : IQueryHandlerAsync<GetRedenenEindeZorg, RedenenEindeZorgViewModel>
{
    private readonly IRedenEindeZorgRepository _repository;

    public GetRedenenEindeZorgHandler(IRedenEindeZorgRepository repository)
    {
        _repository = repository;
    }

    public async Task<RedenenEindeZorgViewModel> HandleAsync(GetRedenenEindeZorg query)
    {
        var model = new RedenenEindeZorgViewModel { RedenenEindeZorg = new List<RedenEindeZorgViewModel>() };
        var dbQuery = _repository.Query().AsNoTracking();

        dbQuery = query.IncludeDeletes
            ? dbQuery
            : dbQuery.Where(x => x.Status != Status.Verwijderd);

        if (query == null)
            return model;


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Code.Contains(match) ||
                                             x.Omschrijving.Contains(match) ||
                                             x.Status.ToString().Contains(match));
            }
        }


        model.RedenenEindeZorg = await dbQuery.Select(x => new RedenEindeZorgViewModel
        {
            Id = x.Id,
            Code = x.Code,
            Omschrijving = x.Omschrijving,
            Status = x.Status
        }).OrderBy(o => o.Code).ToListAsync();

        return model;
    }
}
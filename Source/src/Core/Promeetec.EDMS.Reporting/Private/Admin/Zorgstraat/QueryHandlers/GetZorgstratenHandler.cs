using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.QueryHandlers;

public class GetZorgstratenHandler : IQueryHandlerAsync<GetZorgstraten, ZorgstratenViewModel>
{
    private readonly IZorgstraatRepository _repository;

    public GetZorgstratenHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ZorgstratenViewModel> HandleAsync(GetZorgstraten query)
    {
        var model = new ZorgstratenViewModel { Zorgstraten = new List<ZorgstraatViewModel>() };
        var dbQuery = _repository.Query().AsNoTracking();

        dbQuery = query.IncludeDeletes
            ? dbQuery
            : dbQuery.Where(x => x.Status != Status.Verwijderd);



        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Naam.Contains(match));
            }
        }


        var items = dbQuery.Select(x => new ZorgstraatViewModel
        {
            Id = x.Id,
            Naam = x.Naam,
            Status = x.Status
        });
        model.Zorgstraten = await items.OrderBy(o => o.Naam).ToListAsync();

        return model;
    }
}
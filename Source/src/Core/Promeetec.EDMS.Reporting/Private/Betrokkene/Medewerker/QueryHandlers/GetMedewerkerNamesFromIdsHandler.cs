using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerNamesFromIdsHandler : IQueryHandlerAsync<GetMedewerkerNamesFromIds, IEnumerable<string>>
{
    private readonly IMedewerkerRepository _repository;

    public GetMedewerkerNamesFromIdsHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<string>> HandleAsync(GetMedewerkerNamesFromIds query)
    {
        var dbQuery = await _repository.Query()
            .Where(x => query.Ids.Contains(x.Id))
            .OrderBy(o => o.Persoon.VolledigeNaam)
            .Select(s => s.Persoon.VolledigeNaam)
            .ToListAsync();

        return dbQuery;
    }
}
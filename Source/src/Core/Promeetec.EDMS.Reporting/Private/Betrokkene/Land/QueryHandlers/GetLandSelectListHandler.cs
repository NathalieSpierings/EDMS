using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.QueryHandlers;

public class GetLandSelectListHandler : IQueryHandlerAsync<GetLandSelectList, LandSelectList>
{
    private readonly ILandRepository _repository;

    public GetLandSelectListHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<LandSelectList> HandleAsync(GetLandSelectList query)
    {
        var dbQuery = await _repository.Query()
            .AsNoTracking()
            .OrderBy(o => o.NativeName)
            .ToListAsync();

        return new LandSelectList
        {
            Landen = new SelectList(dbQuery, "Id", "NativeName", dbQuery.FirstOrDefault(x => x.CultureCode == "nl-NL").Id)
        };
    }
}
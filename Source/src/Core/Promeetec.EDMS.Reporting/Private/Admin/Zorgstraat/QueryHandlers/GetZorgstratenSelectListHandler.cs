using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.QueryHandlers;

public class GetZorgstratenSelectListHandler : IQueryHandlerAsync<GetZorgstratenSelectList, ZorgstratenSelectList>
{
    private readonly IZorgstraatRepository _repository;

    public GetZorgstratenSelectListHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ZorgstratenSelectList> HandleAsync(GetZorgstratenSelectList query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.Status == Status.Actief)
            .OrderBy(o => o.Naam);

        return new ZorgstratenSelectList
        {
            Zorgstraten = new SelectList(dbQuery, "Id", "Naam")
        };
    }
}
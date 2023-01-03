using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.QueryHandlers;

public class GetRedenEindeZorgSelectListHandler : IQueryHandlerAsync<GetRedenEindeZorgSelectList, RedenEindeZorgSelectList>
{
    private readonly IRedenEindeZorgRepository _repository;

    public GetRedenEindeZorgSelectListHandler(IRedenEindeZorgRepository repository)
    {
        _repository = repository;
    }

    public async Task<RedenEindeZorgSelectList> HandleAsync(GetRedenEindeZorgSelectList query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.Status == Status.Actief)
            .OrderBy(o => o.Code);

        var result = await dbQuery.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Code + "-" + x.Omschrijving.ToString()
        }).ToListAsync();

        return new RedenEindeZorgSelectList
        {
            RedenenEindeZorg = new SelectList(result, "Value", "Text")
        };
    }
}
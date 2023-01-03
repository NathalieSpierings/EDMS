using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.QueryHandlers;

public class GetRedenEindeZorgHandler : IQueryHandlerAsync<GetRedenEindeZorg, RedenEindeZorgViewModel>
{
    private readonly IRedenEindeZorgRepository _repository;

    public GetRedenEindeZorgHandler(IRedenEindeZorgRepository repository)
    {
        _repository = repository;
    }

    public async Task<RedenEindeZorgViewModel> HandleAsync(GetRedenEindeZorg query)
    {
        var dbQuery = await _repository
            .Query()
            .AsNoTracking()
            .Where(x => x.Id == query.RedenEindeZorgId)
            .FirstOrDefaultAsync();

        if (dbQuery == null)
            return new RedenEindeZorgViewModel();

        return new RedenEindeZorgViewModel
        {
            Id = dbQuery.Id,
            Code = dbQuery.Code,
            Omschrijving = dbQuery.Omschrijving,
            Status = dbQuery.Status
        };
    }
}
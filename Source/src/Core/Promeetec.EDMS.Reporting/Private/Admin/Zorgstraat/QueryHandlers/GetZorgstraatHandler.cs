using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.QueryHandlers;

public class GetZorgstraatHandler : IQueryHandlerAsync<GetZorgstraat, ZorgstraatViewModel>
{
    private readonly IZorgstraatRepository _repository;

    public GetZorgstraatHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ZorgstraatViewModel> HandleAsync(GetZorgstraat query)
    {
        var dbQuery = await _repository
            .Query()
            .Where(x => x.Id == query.ZorgstraatId)
            .FirstOrDefaultAsync();

        if (dbQuery == null)
            return new ZorgstraatViewModel();

        return new ZorgstraatViewModel
        {
            Id = dbQuery.Id,
            Naam = dbQuery.Naam,
            Status = dbQuery.Status
        };
    }
}
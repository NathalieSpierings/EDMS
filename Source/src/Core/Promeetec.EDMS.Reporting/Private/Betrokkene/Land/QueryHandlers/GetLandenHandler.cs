using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.QueryHandlers;

public class GetLandenHandler : IQueryHandlerAsync<GetLanden, LandenViewModel>
{
    private readonly ILandRepository _repository;

    public GetLandenHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<LandenViewModel> HandleAsync(GetLanden query)
    {
        var dbQuery = _repository.Query().AsNoTracking();

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.CultureCode.Contains(match) ||
                                             x.NativeName.Contains(match));
            }
        }

        var items = dbQuery.Select(x => new LandViewModel
        {
            Id = x.Id,
            CultureCode = x.CultureCode,
            NativeName = x.NativeName,
            Status = x.Status
        });

        var model = new LandenViewModel
        {
            Landen = await items.OrderBy(o => o.NativeName).ToListAsync()
        };

        return model;
    }
}
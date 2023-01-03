using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.QueryHandlers;

public class GetLandHandler : IQueryHandlerAsync<GetLand, LandViewModel>
{
    private readonly ILandRepository _repository;

    public GetLandHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public async Task<LandViewModel> HandleAsync(GetLand query)
    {
        if (query.LandId != null && query.LandId != Guid.Empty)
        {
            var model = await _repository.Query()
                .AsNoTracking()
                .Where(x => x.Id == query.LandId)
                .Select(x => new LandViewModel
                {
                    Id = x.Id,
                    CultureCode = x.CultureCode,
                    NativeName = x.NativeName,
                    Status = x.Status
                }).FirstOrDefaultAsync();

            return model;
        }

        if (!string.IsNullOrWhiteSpace(query.LandCode))
        {
            var model = await _repository.Query()
                .AsNoTracking()
                .Where(x => x.CultureCode == query.LandCode)
                .Select(x => new LandViewModel
                {
                    Id = x.Id,
                    CultureCode = x.CultureCode,
                    NativeName = x.NativeName,
                    Status = x.Status
                }).FirstOrDefaultAsync();

            return model;
        }

        return new LandViewModel();
    }
}
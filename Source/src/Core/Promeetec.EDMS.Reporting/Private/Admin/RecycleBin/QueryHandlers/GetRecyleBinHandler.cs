using System.Threading.Tasks;
using Promeetec.EDMS.Domain;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RecycleBin.Models;
using Promeetec.EDMS.Reporting.Private.Admin.RecycleBin.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.RecycleBin.QueryHandlers;

public class GetRecyleBinHandler : IQueryHandlerAsync<GetRecycleBin, RecyleBinViewModel>
{
    private readonly IDomainStore _domainStore;
    public GetRecyleBinHandler(IDomainStore domainStore)
    {
        _domainStore = domainStore;
    }


    public async Task<RecyleBinViewModel> HandleAsync(GetRecycleBin query)
    {
        var events = await _domainStore.GetEventsByTypeNameAsync("Verwijderd");
        var model = new RecyleBinViewModel(events);
        return model;
    }
}
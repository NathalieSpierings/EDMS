using System.Threading.Tasks;
using Promeetec.EDMS.Domain;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Aggregate.QueryHandlers;

public class GetAggregatesHandler : IQueryHandlerAsync<GetAggregates, AggregateViewModel>
{
    private readonly IDomainStore _domainStore;

    public GetAggregatesHandler(IDomainStore domainStore)
    {
        _domainStore = domainStore;
    }

    public async Task<AggregateViewModel> HandleAsync(GetAggregates query)
    {
        var events = await _domainStore.GetAllEventsAsync();
        var aggregate = new AggregateViewModel(events);
        return aggregate;
    }
}
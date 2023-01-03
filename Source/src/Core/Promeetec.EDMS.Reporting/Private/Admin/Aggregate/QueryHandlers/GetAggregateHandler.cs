using System.Threading.Tasks;
using Promeetec.EDMS.Domain;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Aggregate.QueryHandlers;

public class GetAggregateHandler : IQueryHandlerAsync<GetAggregate, AggregateViewModel>
{
    private readonly IDomainStore _domainStore;

    public GetAggregateHandler(IDomainStore domainStore)
    {
        _domainStore = domainStore;
    }

    public async Task<AggregateViewModel> HandleAsync(GetAggregate query)
    {
        var events = await _domainStore.GetEventsAsync(query.AggregateRootId);
        var aggregate = new AggregateViewModel(events);
        return aggregate;
    }
}
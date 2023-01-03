using System.Collections.Generic;
using System.Linq;
using Promeetec.EDMS.Domain;

namespace Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Models;

public class AggregateViewModel
{
    public AggregateViewModel(IEnumerable<IDomainEvent> events)
    {
        var domainEvents = events as IDomainEvent[] ?? events.OrderByDescending(x => x.TimeStamp).ToArray();
        foreach (var @event in domainEvents)
        {
            Events.Add(new EventViewModel(@event));
            Version++;
        }
    }

    public IList<EventViewModel> Events { get; set; } = new List<EventViewModel>();
    public int Version { get; set; }
}
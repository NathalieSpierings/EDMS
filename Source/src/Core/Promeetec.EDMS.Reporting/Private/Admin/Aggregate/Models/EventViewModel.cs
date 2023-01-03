using System;
using System.Collections.Generic;
using System.Linq;
using Promeetec.EDMS.Domain;

namespace Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Models;

public class EventViewModel
{
    public EventViewModel(IDomainEvent @event)
    {
        Id = @event.Id;
        AggregateRootId = @event.AggregateRootId;
        CommandId = @event.CommandId;
        UserId = @event.UserId;
        Medewerker = @event.UserDisplayName;
        Source = @event.Source;
        TimeStamp = @event.TimeStamp;
        Type = @event.GetType().Name;

        var properties = @event.GetType()
            .GetProperties()
            .Where(x => x.Name != nameof(@event.Id) &&
                        x.Name != nameof(@event.AggregateRootId) &&
                        x.Name != nameof(@event.CommandId) &&
                        x.Name != nameof(@event.UserId) &&
                        x.Name != nameof(@event.UserDisplayName) &&
                        x.Name != nameof(@event.Source) &&
                        x.Name != nameof(@event.TimeStamp));

        foreach (var propertyInfo in properties)
        {
            Data.Add(propertyInfo.Name, propertyInfo.GetValue(@event, null)?.ToString());
        }
    }

    public Guid Id { get; set; }
    public Guid AggregateRootId { get; set; }
    public Guid CommandId { get; set; }
    public Guid UserId { get; set; }
    public string Medewerker { get; set; }
    public string Source { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Type { get; set; }
    public Dictionary<string, string> Data { get; set; } = new();
}
using System;
using System.Collections.Generic;
using System.Linq;
using Promeetec.EDMS.Domain;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RecycleBin.Models;

public class RecyleBinViewModel : ModelBase
{
    //public RecyleBinViewModel(IEnumerable<IDomainEvent> events)
    //{
    //    var domainEvents = events as IDomainEvent[] ?? events.OrderByDescending(x => x.TimeStamp).ToArray();
    //    foreach (var @event in domainEvents)
    //    {
    //        var type = @event.GetType().Name;

    //        if (type.EndsWith("Verwijderd"))
    //        {
    //            var name = type.Remove(type.Length - 10);
    //            Enum.TryParse(name, true, out RecyleBinType recyleBinType);

    //            RecyleBinListItems.Add(new RecyleBinListItemViewModel
    //            {
    //                EventId = @event.Id,
    //                CommandId = @event.CommandId,
    //                AggregateRootId = @event.AggregateRootId,
    //                VerwijderdDoor = @event.UserDisplayName,
    //                VerwijderdOp = @event.TimeStamp,
    //                RecyleBinType = recyleBinType
    //            });
    //        }

    //        Version++;
    //    }
    //}

    public int Version { get; set; }

    public List<RecyleBinListItemViewModel> RecyleBinListItems { get; set; } = new();
}
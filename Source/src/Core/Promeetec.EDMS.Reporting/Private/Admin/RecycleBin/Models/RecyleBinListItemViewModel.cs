using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RecycleBin.Models;

public class RecyleBinListItemViewModel : ModelBase
{
    public Guid EventId { get; set; }
    public Guid CommandId { get; set; }
    public Guid AggregateRootId { get; set; }
    public RecyleBinType RecyleBinType { get; set; }
    public string VerwijderdDoor { get; set; }
    public DateTime VerwijderdOp { get; set; }
}
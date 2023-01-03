using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Aggregate.Queries;

public class GetAggregate : IQuery<AggregateViewModel>
{
    public Guid AggregateRootId { get; set; }
}
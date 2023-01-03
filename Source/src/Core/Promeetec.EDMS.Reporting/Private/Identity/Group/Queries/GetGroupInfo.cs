using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

public class GetGroup : IQuery<GroupViewModel>
{
    public Guid GroupId { get; set; }
    public bool IncludeDeletes { get; set; } = false;
}
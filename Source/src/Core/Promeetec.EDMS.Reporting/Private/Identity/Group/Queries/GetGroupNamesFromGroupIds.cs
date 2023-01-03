using System;
using System.Collections.Generic;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

public class GetGroupNamesFromGroupIds : IQuery<IEnumerable<string>>
{
    public IEnumerable<Guid> GroupIds { get; set; }
}
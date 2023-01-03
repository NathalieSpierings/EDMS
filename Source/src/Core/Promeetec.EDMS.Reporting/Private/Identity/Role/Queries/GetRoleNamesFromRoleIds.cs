using System;
using System.Collections.Generic;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

public class GetRoleNamesFromRoleIds : IQuery<IEnumerable<string>>
{
    public IEnumerable<Guid> RoleIds { get; set; }
}
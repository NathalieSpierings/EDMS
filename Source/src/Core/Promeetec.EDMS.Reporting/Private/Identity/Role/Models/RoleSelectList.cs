using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

public class RoleSelectList : ModelBase
{
    public List<RoleSelectListItem> Roles { get; set; }
}

public class RoleSelectListItem : ModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Selected { get; set; }
}
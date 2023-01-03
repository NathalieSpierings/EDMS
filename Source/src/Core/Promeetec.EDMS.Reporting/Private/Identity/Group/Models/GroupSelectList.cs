using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

public class GroupSelectList : ModelBase
{
    public List<GroupSelectListItem> Groups { get; set; }
}

public class GroupSelectListItem : ModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Selected { get; set; }
}
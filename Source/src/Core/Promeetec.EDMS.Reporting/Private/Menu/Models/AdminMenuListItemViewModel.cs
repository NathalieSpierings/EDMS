using System;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class AdminMenuListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MenuType MenuType { get; set; }
    public Status Status { get; set; }
}
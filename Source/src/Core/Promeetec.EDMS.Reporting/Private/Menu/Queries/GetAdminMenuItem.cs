using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Queries;

public class GetAdminMenuItem : IQuery<AdminMenuItemViewModel>
{
    public Guid Id { get; set; }
}
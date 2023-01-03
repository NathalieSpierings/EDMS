using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Queries;

public class GetAdminMenuEdit : IQuery<AdminMenuCreateEditViewModel>
{
    public Guid MenuId { get; set; }
}
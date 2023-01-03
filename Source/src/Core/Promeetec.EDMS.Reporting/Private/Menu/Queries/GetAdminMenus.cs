using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Queries;

public class GetAdminMenus : IQuery<AdminMenusViewModel>
{
    public string SearchTerm { get; set; }
}
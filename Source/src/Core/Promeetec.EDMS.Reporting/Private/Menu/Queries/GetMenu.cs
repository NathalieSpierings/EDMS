using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Queries;

public class GetMenu : IQuery<MenuViewModel>
{
    public string Name { get; set; }
}
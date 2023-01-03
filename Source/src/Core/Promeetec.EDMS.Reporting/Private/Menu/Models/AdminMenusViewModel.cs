using System.Linq;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class AdminMenusViewModel : ModelBase
{
    public IQueryable<AdminMenuListItemViewModel> Menus { get; set; }
}

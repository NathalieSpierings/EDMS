using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Events;

public class MenuItemsGesorteerd : EventBase
{
    public string OudeSorteerVolgorder { get; set; }
    public string NieuweSorteerVolgorder { get; set; }

}

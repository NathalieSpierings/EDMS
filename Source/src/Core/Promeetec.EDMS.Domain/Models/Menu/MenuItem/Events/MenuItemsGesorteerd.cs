using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Events;

public class MenuItemsGesorteerd : EventBase
{
    public string OudeSorteerVolgorder { get; set; }
    public string NieuweSorteerVolgorder { get; set; }

}

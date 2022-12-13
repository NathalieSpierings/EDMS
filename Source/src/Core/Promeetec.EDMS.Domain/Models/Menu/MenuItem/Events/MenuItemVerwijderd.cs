using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Events;

public class MenuItemVerwijderd : EventBase
{
    public string Status { get; set; }
}
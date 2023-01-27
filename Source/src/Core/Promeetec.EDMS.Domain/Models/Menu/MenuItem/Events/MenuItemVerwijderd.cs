using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Events;

public class MenuItemVerwijderd : EventBase
{
    public string Status { get; set; }
}
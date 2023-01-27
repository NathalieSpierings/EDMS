using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Events;

public class MenuItemGewijzigd : EventBase
{
    public Guid MenuId { get; set; }
    public Guid? ParentId { get; set; }
    public string ClientName { get; set; }
    public string Key { get; set; }
    public string Title { get; set; }
    public string Tooltip { get; set; }
    public string Icon { get; set; }
    public string ActionName { get; set; }
    public string ControllerName { get; set; }
    public object RouteVariables { get; set; }
    public string Url { get; set; }
    public string Disabled { get; set; }
    public string Status { get; set; }
    public string Soort { get; set; }
}

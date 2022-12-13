using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands
{
    public class AddMenuItem : CommandBase
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
        public string RouteVariables { get; set; }
        public string Url { get; set; }
        public bool Disabled { get; set; }
        public Status Status { get; set; }
        public MenuItemType MenuItemType { get; set; }
        public List<MenuItemRole> Roles { get; set; } = new List<MenuItemRole>();
    }
}

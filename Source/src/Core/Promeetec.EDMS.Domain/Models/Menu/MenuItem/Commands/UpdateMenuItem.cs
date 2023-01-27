using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands
{
    public class UpdateMenuItem : CommandBase
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

    }
}

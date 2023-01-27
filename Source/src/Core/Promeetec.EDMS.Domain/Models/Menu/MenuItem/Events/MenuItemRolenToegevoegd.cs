using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Events
{
    public class MenuItemRolenToegevoegd : EventBase
    {
        public Guid MenuItemId { get; set; }
        public IList<MenuItemRole> MenuItemRoles { get; set; }
    }
}
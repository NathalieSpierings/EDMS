using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Events
{
    public class MenuItemRolenToegevoegd : EventBase
    {
        public Guid MenuItemId { get; set; }
        public IList<MenuItemRole> MenuItemRoles { get; set; }
    }
}
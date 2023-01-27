using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands
{
    public class RemoveMenuItem : CommandBase
    {
        public Guid MenuId { get; set; }
        public Guid MenuItemId { get; set; }
    }
}

using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands;

public class ReorderMenuItems : CommandBase
{
    public Guid MenuId { get; set; }
    public IList<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
    }
}
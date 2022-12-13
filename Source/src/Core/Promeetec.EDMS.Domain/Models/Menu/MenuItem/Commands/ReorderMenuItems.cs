using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;

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
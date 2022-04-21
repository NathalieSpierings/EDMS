using Promeetec.EDMS.Domain.Domain.Identity.Role;

namespace Promeetec.EDMS.Domain.Domain.Menu;

public class MenuItemRole
{
    public Guid MenuItemId { get; set; }
    public virtual MenuItem MenuItem { get; set; }

    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}
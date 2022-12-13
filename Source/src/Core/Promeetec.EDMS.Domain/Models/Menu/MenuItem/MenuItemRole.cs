using System;
using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem;

public class MenuItemRole
{
    public Guid MenuItemId { get; set; }
    public virtual MenuItem MenuItem { get; set; }

    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}
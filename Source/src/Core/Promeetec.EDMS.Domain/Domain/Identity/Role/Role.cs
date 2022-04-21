using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Domain.Identity.Group;
using Promeetec.EDMS.Domain.Domain.Menu;
using Promeetec.EDMS.Domain.Domain.Shared;

namespace Promeetec.EDMS.Domain.Domain.Identity.Role;

public class Role : IdentityRole<Guid>
{
    /// <summary>
    /// The discription of the role.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The status of the role.
    /// <list type="bullet">
    /// <item>
    /// <description>Suspended: Role cannot be used.</description>
    /// </item>
    /// <item>
    /// <description>Active: Role is active and in use.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; private set; }


    #region Navigation properties

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
    public ICollection<GroupRole> Groups { get; set; } = new List<GroupRole>();
    public ICollection<MenuItemRole> MenuItems { get; set; } = new List<MenuItemRole>();


    #endregion


    /// <summary>
    /// Creates an empty role.
    /// </summary>
    public Role()
    {
    }

}

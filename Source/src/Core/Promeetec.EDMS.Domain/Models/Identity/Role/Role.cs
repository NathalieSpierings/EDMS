using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Identity.Role;

public class Role : IdentityRole<Guid>, IAggregateRoot
{
    /// <summary>
    /// The discription of the role.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The status of the role.
    /// </summary>
    public Status Status { get; set; }


    #region Navigation properties

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
    public ICollection<GroupRole> Groups { get; set; }
    public ICollection<MenuItemRole> MenuItems { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty role.
    /// </summary>
    public Role()
    {
        Id = Guid.NewGuid();
    }

    public Role(Guid id) : this()
    {
        if (id == Guid.Empty)
            id = Guid.NewGuid();

        Id = id;
    }

    #region AggregateRoot implementations

    public override Guid Id { get; set; }

    #endregion
}

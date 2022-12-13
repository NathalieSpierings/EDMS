using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem;
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

    /// <summary>
    /// Creates an empty role.
    /// </summary>
    public Role(Guid id) : this()
    {
        if (id == Guid.Empty)
            id = Guid.NewGuid();

        Id = id;
    }

    /// <summary>
    /// Creates a role.
    /// </summary>
    /// <param name="cmd">The create role command.</param>
    public Role(CreateRole cmd)
    {
        Id = cmd.Id;

        Name = cmd.Name;
        Description = cmd.Description;
        Status = Status.Actief;
    }

    /// <summary>
    /// Update the details of the role.
    /// </summary>
    /// <param name="cmd">The update role command.</param>
    public void Update(UpdateRole cmd)
    {
        Name = cmd.Name;
        Description = cmd.Description;
    }

    /// <summary>
    /// Deletes a role.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }

    #region AggregateRoot implementations

    public override Guid Id { get; set; }

    #endregion
}

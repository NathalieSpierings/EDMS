using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group;

public class Group : AggregateRoot
{
    /// <summary>
    /// The name of the group.
    /// </summary>
    [Required, MaxLength(200)]
    public string Name { get; set; }

    /// <summary>
    /// The description of the group.
    /// </summary>
    [MaxLength(1024)]
    public string? Description { get; set; }

    public Status Status { get; set; }

    #region Navigation properties

    public virtual ICollection<GroupRole> Roles { get; set; }
    public virtual ICollection<GroupUser> Users { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty group.
    /// </summary>
    public Group()
    {

    }


    /// <summary>
    /// Creates a group.
    /// </summary>
    /// <param name="cmd">The create group command.</param>
    public Group(CreateGroup cmd)
    {
        Id = cmd.Id;

        Name = cmd.Name;
        Description = cmd.Description;
        Status = Status.Actief;
    }

    /// <summary>
    /// Update the details of the group.
    /// </summary>
    /// <param name="cmd">The update group command.</param>
    public void Update(UpdateGroup cmd)
    {
        Name = cmd.Name;
        Description = cmd.Description;
    }

    /// <summary>
    /// Deletes a group.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }
}
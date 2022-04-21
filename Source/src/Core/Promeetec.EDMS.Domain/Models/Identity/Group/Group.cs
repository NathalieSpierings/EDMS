using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Identity.Group;

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
    public string Description { get; set; }


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
}
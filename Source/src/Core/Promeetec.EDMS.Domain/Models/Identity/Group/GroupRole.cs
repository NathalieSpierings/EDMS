namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group;

public class GroupRole
{
    public Guid GroupId { get; set; }
    public virtual Identity.Group.Group Group { get; set; }

    public Guid RoleId { get; set; }
    public virtual Role.Role Role { get; set; }
}
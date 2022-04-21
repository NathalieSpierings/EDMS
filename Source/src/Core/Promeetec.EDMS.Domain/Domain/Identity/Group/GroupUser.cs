namespace Promeetec.EDMS.Domain.Domain.Identity.Group;

public class GroupUser
{
    public Guid UserId { get; set; }
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }

    public Guid GroupId { get; set; }
    public virtual Identity.Group.Group Group { get; set; }
}
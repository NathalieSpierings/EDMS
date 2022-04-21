using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Domain.Models.Identity;

public class UserRole : IdentityUserRole<Guid>
{
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }
    public virtual Role.Role Role { get; set; }
}
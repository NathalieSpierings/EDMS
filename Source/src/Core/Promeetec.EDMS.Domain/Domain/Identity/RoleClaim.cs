using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Domain.Domain.Identity;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public virtual Role.Role Role { get; set; }
}
using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Domain.Domain.Identity;

public class UserClaim : IdentityUserClaim<Guid>
{
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }
}
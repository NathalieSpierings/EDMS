using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Domain.Domain.Identity;

public class UserLogin : IdentityUserLogin<Guid>
{
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }
}
using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity;

public class UserLogin : IdentityUserLogin<Guid>
{
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }
}
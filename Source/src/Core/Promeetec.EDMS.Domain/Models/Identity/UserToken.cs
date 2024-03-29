﻿using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity;

public class UserToken : IdentityUserToken<Guid>
{
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }
}
﻿using Microsoft.AspNetCore.Identity;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public virtual Role.Role Role { get; set; }
}
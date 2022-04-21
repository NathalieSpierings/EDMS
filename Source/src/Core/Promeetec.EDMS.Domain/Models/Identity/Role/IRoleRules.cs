﻿namespace Promeetec.EDMS.Domain.Models.Identity.Role;

public interface IRoleRules
{
    Task<bool> IsNameUniqueAsync(string name);
    Task<bool> IsNameUniqueAsync(string name, Guid id);
}
using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

namespace Promeetec.EDMS.Domain.Models.Identity.Role;

public interface IRoleRepository : IRepository<Role>
{
    /// <summary>
    /// Removes from role asynchronous.
    /// </summary>
    /// <param name="medewerker">The medewerker.</param>
    /// <param name="roleName">Name of the role.</param>
    Task<IdentityResult> RemoveFromRoleAsync(Medewerker medewerker, string roleName);

    /// <summary>
    /// Removes from roles asynchronous.
    /// </summary>
    /// <param name="medewerker">The medewerker.</param>
    /// <param name="roleNames">The role names.</param>
    Task<IdentityResult> RemoveFromRolesAsync(Medewerker medewerker, string[] roleNames);

    /// <summary>
    /// Adds to role asynchronous.
    /// </summary>
    /// <param name="medewerker">The medewerker.</param>
    /// <param name="roleName">Name of the role.</param>
    Task<IdentityResult> AddToRoleAsync(Medewerker medewerker, string roleName);

    /// <summary>
    /// Adds to roles asynchronous.
    /// </summary>
    /// <param name="medewerker">The medewerker.</param>
    /// <param name="roleNames">The role names.</param>
    Task<IdentityResult> AddToRolesAsync(Medewerker medewerker, string[] roleNames);

    /// <summary>
    /// Gets the roles.
    /// </summary>
    /// <param name="roleIds">The role ids.</param>
    IEnumerable<Role> GetRoles(IEnumerable<Guid> roleIds);
}
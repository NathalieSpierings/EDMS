using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Data.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly UserManager<Medewerker> _userManager;

    public RoleRepository(EDMSDbContext context, UserManager<Medewerker> userManager)
        : base(context)
    {
        _userManager = userManager;

        //_userManager.UserValidator = new UserValidator<Medewerker, Guid>(_userManager)
        //{
        //    AllowOnlyAlphanumericUserNames = false
        //};
    }

    /// <inheritdoc />
    public async Task<IdentityResult> RemoveFromRoleAsync(Medewerker medewerker, string roleName)
    {
        var result = await _userManager.RemoveFromRoleAsync(medewerker, roleName);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> RemoveFromRolesAsync(Medewerker medewerker, string[] roleNames)
    {
        var result = await _userManager.RemoveFromRolesAsync(medewerker, roleNames);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> AddToRoleAsync(Medewerker medewerker, string roleName)
    {
        var result = await _userManager.AddToRoleAsync(medewerker, roleName);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> AddToRolesAsync(Medewerker medewerker, string[] roleNames)
    {
        var result = new IdentityResult();
        foreach (var role in roleNames)
        {
            if (!await _userManager.IsInRoleAsync(medewerker, role))
                result = await _userManager.AddToRoleAsync(medewerker, role);
        }

        return result;
    }


    /// <inheritdoc />
    public IEnumerable<Role> GetRoles(IEnumerable<Guid> roleIds)
    {
        var result = new List<Role>();
        var dbEntities = Query().Where(x => roleIds.Contains(x.Id));
        if (dbEntities != null)
            result.AddRange(dbEntities);

        return result;
    }
}
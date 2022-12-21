using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

namespace Promeetec.EDMS.Domain.Models.Identity.Users;

public class UserClaimsTransformation : IClaimsTransformation
{
    private readonly UserManager<Medewerker> _userManager;

    public UserClaimsTransformation(UserManager<Medewerker> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = principal.Identities.FirstOrDefault(c => c.IsAuthenticated);
        if (identity == null)
            return principal;

        var user = await _userManager.GetUserAsync(principal);
        if (user == null)
            return principal;

        if (!principal.HasClaim(c => c.Type == "OrganisatieId"))
            identity.AddClaim(new Claim("OrganisatieId", user.OrganisatieId.ToString()));

        if (!principal.HasClaim(c => c.Type == "Organisatie"))
            identity.AddClaim(new Claim("Organisatie", $"{user.Organisatie.Naam} ({user.Organisatie.Nummer})" ?? string.Empty));

        if (!principal.HasClaim(c => c.Type == "IsActive"))
            identity.AddClaim(new Claim("IsActive", user.IsActive.ToString()));

        if (!principal.HasClaim(c => c.Type == ClaimTypes.GivenName))
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Persoon.VolledigeNaam ?? string.Empty));

        return new ClaimsPrincipal(identity);
    }
}

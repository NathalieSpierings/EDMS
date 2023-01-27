using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Queries;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Reporting.Public.User.Models;

namespace Promeetec.EDMS.Portaal.Reporting.Public.User.Queries;

public class GetCurrentUser : IQuery<CurrentUserModel>
{

}

public class GetCurrentUserHandler : IQueryHandler<GetCurrentUser, CurrentUserModel>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMedewerkerRepository _repository;

    public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, IMedewerkerRepository repository)
    {
        _httpContextAccessor = httpContextAccessor;
        _repository = repository;
    }


    public async Task<CurrentUserModel> Handle(GetCurrentUser query)
    {
        var result = new CurrentUserModel();
        var claimsPrincipal = _httpContextAccessor.HttpContext.User;
        if (claimsPrincipal.Identity.IsAuthenticated)
        {
            var identityUserId = _httpContextAccessor.HttpContext.User.Identities
                .First().Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(identityUserId))
            {
                var user = await _repository.Query()
                    .Include(i => i.Organisatie)
                    .FirstOrDefaultAsync(x => x.Id == Guid.Parse(identityUserId));

                if (user != null)
                {
                    result = new CurrentUserModel
                    {
                        Id = user.Id,
                        IdentityUserId = identityUserId,
                        Email = user.Email,
                        DisplayName = user.Persoon.VolledigeNaam,
                        IsActive = user.IsActive,
                        IsAuthenticated = true,
                        OrganisatieId = user.OrganisatieId,
                        Organisatie = $"{user.Organisatie.Naam} ({user.Organisatie.Nummer})"
                    };
                }
            }
        }
        return result;
    }
}
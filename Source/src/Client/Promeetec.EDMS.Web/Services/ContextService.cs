using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Reporting.Public.User.Models;

namespace Promeetec.EDMS.Web.Services
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly EDMSDbContext _context;

        public ContextService(IHttpContextAccessor httpContextAccessor, EDMSDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<CurrentUserModel> CurrentUserAsync()
        {
            var result = new CurrentUserModel();
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                var identityUserId = _httpContextAccessor.HttpContext.User.Identities.First().Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(identityUserId))
                {
                    var user = await _context.Medewerkers.Include(i => i.Organisatie).FirstOrDefaultAsync(x => x.Id == Guid.Parse(identityUserId));

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
}
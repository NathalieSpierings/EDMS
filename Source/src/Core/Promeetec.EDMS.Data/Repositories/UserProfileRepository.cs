using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Data.Repositories;

public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
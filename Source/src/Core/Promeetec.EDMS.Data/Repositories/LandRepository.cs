using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;

namespace Promeetec.EDMS.Data.Repositories;

public class LandRepository : Repository<Land>, ILandRepository
{
    public LandRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
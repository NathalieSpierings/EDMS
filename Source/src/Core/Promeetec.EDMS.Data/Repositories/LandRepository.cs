using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class LandRepository : Repository<Land>, ILandRepository
{
    public LandRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
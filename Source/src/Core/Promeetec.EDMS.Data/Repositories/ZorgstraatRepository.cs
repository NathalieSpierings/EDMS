using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class ZorgstraatRepository : Repository<Zorgstraat>, IZorgstraatRepository
{
    public ZorgstraatRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;

namespace Promeetec.EDMS.Data.Repositories;

public class ZorgstraatRepository : Repository<Zorgstraat>, IZorgstraatRepository
{
    public ZorgstraatRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
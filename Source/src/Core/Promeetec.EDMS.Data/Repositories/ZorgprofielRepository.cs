using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Data.Repositories;

public class ZorgprofielRepository : Repository<Zorgprofiel>, IZorgprofielRepository
{
    public ZorgprofielRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class ZorgprofielRepository : Repository<Zorgprofiel>, IZorgprofielRepository
{
    public ZorgprofielRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
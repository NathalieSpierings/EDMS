using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.EiStandaard;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class EiStandaardRepository : Repository<EiStandaard>, IEiStandaardRepository
{
    public EiStandaardRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
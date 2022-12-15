using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;

namespace Promeetec.EDMS.Data.Repositories;

public class EiStandaardRepository : Repository<EiStandaard>, IEiStandaardRepository
{
    public EiStandaardRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
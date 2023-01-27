using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class MededelingRepository : Repository<Mededeling>, IMededelingRepository
{
    public MededelingRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
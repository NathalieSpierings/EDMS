using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;

namespace Promeetec.EDMS.Data.Repositories;

public class MededelingRepository : Repository<Mededeling>, IMededelingRepository
{
    public MededelingRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
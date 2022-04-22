using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

namespace Promeetec.EDMS.Data.Repositories;

public class MedewerkerRepository : Repository<Medewerker>, IMedewerkerRepository
{
    public MedewerkerRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
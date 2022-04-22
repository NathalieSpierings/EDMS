using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;

namespace Promeetec.EDMS.Data.Repositories;

public class AdresRepository : Repository<Adres>, IAdresRepository
{
    public AdresRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
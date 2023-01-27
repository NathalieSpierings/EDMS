using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class AdresRepository : Repository<Adres>, IAdresRepository
{
    public AdresRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class VerzekeraarRepository : Repository<Verzekeraar>, IVerzekeraarRepository
{
    public VerzekeraarRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
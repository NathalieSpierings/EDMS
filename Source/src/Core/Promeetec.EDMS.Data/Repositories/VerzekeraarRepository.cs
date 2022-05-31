using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;

namespace Promeetec.EDMS.Data.Repositories;

public class VerzekeraarRepository : Repository<Verzekeraar>, IVerzekeraarRepository
{
    public VerzekeraarRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
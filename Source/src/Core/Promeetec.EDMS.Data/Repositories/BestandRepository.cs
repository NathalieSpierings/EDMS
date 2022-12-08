using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Document.Bestand;

namespace Promeetec.EDMS.Data.Repositories;

public class BestandRepository : Repository<Bestand>, IBestandRepository
{
    public BestandRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
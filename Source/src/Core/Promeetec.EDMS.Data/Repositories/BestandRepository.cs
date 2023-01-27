using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class BestandRepository : Repository<Bestand>, IBestandRepository
{
    public BestandRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
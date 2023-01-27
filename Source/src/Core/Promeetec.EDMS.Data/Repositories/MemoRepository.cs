using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class MemoRepository : Repository<Memo>, IMemoRepository
{
    public MemoRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo;

namespace Promeetec.EDMS.Data.Repositories;

public class MemoRepository : Repository<Memo>, IMemoRepository
{
    public MemoRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
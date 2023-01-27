using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class ChangelogRepository : Repository<Changelog>, IChangelogRepository
{
    public ChangelogRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
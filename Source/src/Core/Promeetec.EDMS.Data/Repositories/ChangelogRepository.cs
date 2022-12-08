using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Changelog;

namespace Promeetec.EDMS.Data.Repositories;

public class ChangelogRepository : Repository<Changelog>, IChangelogRepository
{
    public ChangelogRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
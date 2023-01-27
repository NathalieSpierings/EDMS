using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.DownloadActivity;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class DownloadActivityRepository : Repository<DownloadActivity>, IDownloadActivityRepository
{
    public DownloadActivityRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
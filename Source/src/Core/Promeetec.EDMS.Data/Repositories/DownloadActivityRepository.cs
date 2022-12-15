using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.DownloadActivity;

namespace Promeetec.EDMS.Data.Repositories;

public class DownloadActivityRepository : Repository<DownloadActivity>, IDownloadActivityRepository
{
    public DownloadActivityRepository(EDMSDbContext context)
        : base(context)
    {
    }
}
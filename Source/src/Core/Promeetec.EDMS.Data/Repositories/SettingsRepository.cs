using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.Settings;

namespace Promeetec.EDMS.Data.Repositories;

public class SettingsRepository : Repository<Domain.Models.Admin.Settings.Settings>, ISettingsRepository
{
    public SettingsRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Settings;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class SettingsRepository : Repository<Domain.Models.Admin.Settings.Settings>, ISettingsRepository
{
    public SettingsRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
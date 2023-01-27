using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public async Task<MenuItem?> GetMenuItemWithRoles(Guid id)
    {
        var dbQuery = await Query()
            .Include(i => i.Roles)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        return dbQuery;
    }
}
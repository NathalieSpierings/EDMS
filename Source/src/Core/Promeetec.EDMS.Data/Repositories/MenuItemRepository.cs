using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem;

namespace Promeetec.EDMS.Data.Repositories;

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
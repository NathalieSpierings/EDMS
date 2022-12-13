using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Menu.Menu;

namespace Promeetec.EDMS.Data.Repositories;

public class MenuRepository : Repository<Menu>, IMenuRepository
{
    public MenuRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public async Task<Menu?> GetMenuWithChildrenByIdAsync(Guid id)
    {
        var dbQuery = await Query()
            .Include(i => i.MenuItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        return dbQuery;
    }
}
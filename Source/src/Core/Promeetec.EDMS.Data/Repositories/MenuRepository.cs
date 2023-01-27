using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

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
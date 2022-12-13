namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem;

public interface IMenuItemRepository : IRepository<MenuItem>
{
    Task<MenuItem?> GetMenuItemWithRoles(Guid id);
}
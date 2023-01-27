using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;

public interface IMenuItemRepository : IRepository<MenuItem>
{
    Task<MenuItem?> GetMenuItemWithRoles(Guid id);
}
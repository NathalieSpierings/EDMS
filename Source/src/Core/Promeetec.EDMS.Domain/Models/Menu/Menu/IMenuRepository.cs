using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu;

public interface IMenuRepository : IRepository<Menu>
{
    Task<Menu?> GetMenuWithChildrenByIdAsync(Guid id);
}
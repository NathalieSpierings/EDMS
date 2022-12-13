namespace Promeetec.EDMS.Domain.Models.Menu.Menu;

public interface IMenuRepository : IRepository<Menu>
{
    Task<Menu?> GetMenuWithChildrenByIdAsync(Guid id);
}
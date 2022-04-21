namespace Promeetec.EDMS.Domain.Menu
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Menu GetMenuById(Guid id);
        Menu GetByName(string name);
        Task UpdateMenuAsync(Menu menu);
    }
}
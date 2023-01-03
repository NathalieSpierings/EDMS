using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;
using Promeetec.EDMS.Reporting.Private.Menu.Queries;

namespace Promeetec.EDMS.Reporting.Private.Menu.QueryHandlers;

public class GetAdminMenuItemHandler : IQueryHandlerAsync<GetAdminMenuItem, AdminMenuItemViewModel>
{
    private readonly IMenuItemRepository _repository;
    public GetAdminMenuItemHandler(IMenuItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminMenuItemViewModel> HandleAsync(GetAdminMenuItem query)
    {
        var dbQuery = await _repository.Query()
            .Include(i => i.Roles)
            .Where(x => x.Id == query.Id)
            .FirstOrDefaultAsync();

        var model = new AdminMenuItemViewModel
        {
            Id = dbQuery.Id,
            ClientName = dbQuery.ClientName,
            Key = dbQuery.Key,
            Title = dbQuery.Title,
            Tooltip = dbQuery.Tooltip,
            Icon = dbQuery.Icon,
            ActionName = dbQuery.ActionName,
            ControllerName = dbQuery.ControllerName,
            RouteVariables = dbQuery.RouteVariables,
            Url = dbQuery.Url,
            SortOrder = dbQuery.SortOrder,
            MenuItemType = dbQuery.MenuItemType,
            Status = dbQuery.Status,
            ParentId = dbQuery.ParentId,
            MenuId = dbQuery.MenuId,
            Roles = dbQuery.Roles
        };

        return model;
    }
}
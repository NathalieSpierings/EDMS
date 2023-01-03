using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;
using Promeetec.EDMS.Reporting.Private.Menu.Queries;

namespace Promeetec.EDMS.Reporting.Private.Menu.QueryHandlers;

public class GetAdminMenuItemEditHandler : IQueryHandlerAsync<GetAdminMenuItemEdit, AdminMenuItemCreateEditViewModel>
{
    private readonly IMenuItemRepository _repository;

    public GetAdminMenuItemEditHandler(IMenuItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminMenuItemCreateEditViewModel> HandleAsync(GetAdminMenuItemEdit query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository
            .Query()
            .Include(i => i.Roles)
            .FirstOrDefault(x => x.Id == query.MenuItemId);

        if (dbQuery == null)
            return new AdminMenuItemCreateEditViewModel();

        return new AdminMenuItemCreateEditViewModel
        {
            Id = dbQuery.Id,
            MenuId = dbQuery.MenuId,
            ParentId = dbQuery.ParentId,
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
            Roles = new List<MenuItemRole>(dbQuery.Roles)
        };
    }
}
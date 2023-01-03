using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;
using Promeetec.EDMS.Reporting.Private.Menu.Queries;

namespace Promeetec.EDMS.Reporting.Private.Menu.QueryHandlers;

public class GetAdminMenuEditHandler : IQueryHandlerAsync<GetAdminMenuEdit, AdminMenuCreateEditViewModel>
{
    private readonly IMenuRepository _repository;
    public GetAdminMenuEditHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminMenuCreateEditViewModel> HandleAsync(GetAdminMenuEdit query)
    {
        var dbQuery = await _repository.Query()
            .Include(i => i.MenuItems)
            .Include(i => i.MenuItems.Select(x => x.Roles))
            .Where(x => x.Id == query.MenuId)
            .FirstOrDefaultAsync();

        var model = new AdminMenuCreateEditViewModel
        {
            Id = dbQuery.Id,
            Name = dbQuery.Name,
            MenuType = dbQuery.MenuType,
            Status = dbQuery.Status,
            MenuItems = PopulateMenuItemsForAdmin(dbQuery.MenuItems.AsQueryable(), null)
        };
        return model;
    }

    private List<AdminMenuEditListItemViewModel> PopulateMenuItemsForAdmin(IQueryable<MenuItem> source, Guid? parentId)
    {
        var result = new List<AdminMenuEditListItemViewModel>();

        foreach (var menuItem in source.Where(x => x.ParentId == parentId).OrderBy(x => x.SortOrder))
        {
            var url = "javascript:";
            var roles = menuItem.Roles.Select(x => x.Role.Name);

            if (!string.IsNullOrWhiteSpace(menuItem.Url))
                url = menuItem.Url;

            var menuItemModel = new AdminMenuEditListItemViewModel
            {
                Id = menuItem.Id,
                ClientName = menuItem.ClientName,
                Key = menuItem.Key,
                Title = menuItem.Title,
                Tooltip = menuItem.Tooltip,
                Icon = menuItem.Icon,
                ActionName = menuItem.ActionName,
                ControllerName = menuItem.ControllerName,
                RouteVariables = menuItem.RouteVariables,
                Url = url,
                MenuItemType = menuItem.MenuItemType,
                SortOrder = menuItem.SortOrder,
                ParentId = menuItem.ParentId,
                MenuId = menuItem.MenuId,
                Status = menuItem.Status
            };

            menuItemModel.Children.AddRange(PopulateMenuItemsForAdmin(source, menuItem.Id));

            result.Add(menuItemModel);
        }

        return result;
    }

}
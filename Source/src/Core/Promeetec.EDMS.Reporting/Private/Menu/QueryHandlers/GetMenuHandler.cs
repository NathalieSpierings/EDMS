using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;
using Promeetec.EDMS.Reporting.Private.Menu.Queries;

namespace Promeetec.EDMS.Reporting.Private.Menu.QueryHandlers;

public class GetMenuHandler : IQueryHandler<GetMenu, MenuViewModel>
{
    private readonly IMenuRepository _repository;

    public GetMenuHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public MenuViewModel Handle(GetMenu query)
    {
        var dbQuery = _repository
            .Query()
            .AsNoTracking()
            .Include(i => i.MenuItems)
            .Include(i => i.MenuItems.Select(x => x.Roles))
            .FirstOrDefault(x => x.Name.ToLower() == query.Name.ToLower());

        var model = new MenuViewModel
        {
            Id = dbQuery.Id,
            Name = dbQuery.Name,
            MenuItems = PopulateMenuItems(dbQuery.MenuItems.AsQueryable(), null)
        };

        return model;
    }

    private List<MenuItemViewModel> PopulateMenuItems(IQueryable<MenuItem> source, Guid? parentId)
    {
        var result = new List<MenuItemViewModel>();

        foreach (var menuItem in source.Where(x => x.ParentId == parentId).OrderBy(x => x.SortOrder))
        {
            var url = "javascript:";
            var roles = menuItem.Roles.Select(x => x.Role.Name);

            if (!string.IsNullOrWhiteSpace(menuItem.Url))
                url = menuItem.Url;

            var menuItemModel = new MenuItemViewModel
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
                Status = menuItem.Status,
                RoleNames = roles
            };

            menuItemModel.Children.AddRange(PopulateMenuItems(source, menuItem.Id));

            result.Add(menuItemModel);
        }

        return result;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class MenuItemViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Client naam (html id attribute)")]
    public string ClientName { get; set; }


    [Display(Name = "Key (html data attribute key)")]
    public string Key { get; set; }


    [Display(Name = "Titel")]
    public string Title { get; set; }

    public string Tooltip { get; set; }

    public string Icon { get; set; }


    [Display(Name = "Action naam")]
    public string ActionName { get; set; }


    [Display(Name = "Controller naam")]
    public string ControllerName { get; set; }


    [Display(Name = "Route variables")]
    public object RouteVariables { get; set; }

    public string Url { get; set; }

    [Display(Name = "Sorteervolgorder")]
    public int SortOrder { get; set; }


    [Display(Name = "Soort")]
    public MenuItemType MenuItemType { get; set; }


    [Display(Name = "Uitgeschakeld")]
    public bool Disabled { get; set; }

    public Status Status { get; set; }

    public Guid? ParentId { get; set; }
    public Guid MenuId { get; set; }

    public IEnumerable<string> RoleNames { get; set; } = new List<string>();
    public List<MenuItemViewModel> Children { get; set; } = new();
}
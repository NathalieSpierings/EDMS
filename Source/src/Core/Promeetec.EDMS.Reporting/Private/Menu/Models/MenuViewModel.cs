using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class MenuViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Naam")]
    public string Name { get; set; }


    [Display(Name = "Soort")]
    public MenuType Type { get; set; }

    public Status Status { get; set; }

    public IList<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();

}
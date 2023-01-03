using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class AdminMenuItemCreateEditViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public Guid? ParentId { get; set; }


    [Display(Name = "Client naam")]
    [StringLength(200, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string ClientName { get; set; }


    [Display(Name = "Client Key")]
    public string Key { get; set; }


    [Display(Name = "Titel")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    [StringLength(200, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string Title { get; set; }


    [StringLength(200, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string Tooltip { get; set; }


    [Display(Name = "Icon naam")]
    [StringLength(200, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string Icon { get; set; }



    [Display(Name = "Actie naam")]
    [StringLength(450, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string ActionName { get; set; }


    [Display(Name = "Controller naam")]
    [StringLength(450, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string ControllerName { get; set; }


    [Display(Name = "Route variablen")]
    public object RouteVariables { get; set; }


    [StringLength(450, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string Url { get; set; }

    public int SortOrder { get; set; }


    [Display(Name = "Uitgeschakeld")]
    public bool Disabled { get; set; } = false;


    [Display(Name = "Soort menu item")]
    public MenuItemType MenuItemType { get; set; }

    public Status Status { get; set; }


    public RoleSelectList RoleSelect { get; set; }

    public List<MenuItemRole> Roles { get; set; } = new();
}
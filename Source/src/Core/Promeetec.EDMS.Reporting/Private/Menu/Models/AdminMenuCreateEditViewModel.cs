using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Menu.Models;

public class AdminMenuCreateEditViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Naam")]
    [StringLength(200, ErrorMessage = "De {0} kan maximaal {2} tekens bevatten.")]
    public string Name { get; set; }

    [Display(Name = "Soort menu")]
    public MenuType MenuType { get; set; }

    public Status Status { get; set; }
    public IList<AdminMenuEditListItemViewModel> MenuItems { get; set; } = new List<AdminMenuEditListItemViewModel>();

}
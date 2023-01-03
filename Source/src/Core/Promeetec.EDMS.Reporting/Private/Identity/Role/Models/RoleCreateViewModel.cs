using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

public class RoleCreateViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Naam")]
    [Required(ErrorMessage = "Rol naam is verplicht.")]
    [StringLength(256, ErrorMessage = "De {0} moet minstens {2} tekens bevatten.", MinimumLength = 2)]
    public string Name { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Omschrijving")]
    public string Description { get; set; }


    [Display(Name = "Rol soort")]
    public RoleType RoleType { get; set; }
}
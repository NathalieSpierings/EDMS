using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

public class GroupCreateViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Naam")]
    [Required(ErrorMessage = "Groepsnaam is verplicht.")]
    [StringLength(256, ErrorMessage = "De {0} moet minstens {2} tekens bevatten.", MinimumLength = 2)]
    public string Name { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Omschrijving")]
    public string Description { get; set; }

    [Display(Name = "Status")]
    [Required(ErrorMessage = "Status is verplicht.")]
    public Status Status { get; set; }
    public SelectList Statussen { get; set; }


    public RoleSelectList RoleSelect { get; set; }

    public List<GroupRole> Roles { get; set; } = new();
    public List<GroupUser> Users { get; set; } = new();
}
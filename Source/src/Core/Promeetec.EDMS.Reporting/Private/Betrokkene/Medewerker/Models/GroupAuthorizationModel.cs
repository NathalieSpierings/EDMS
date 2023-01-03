using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class GroupAuthorizationViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }

    [Display(Name = "VECOZO nummer")]
    public string VecozoNummer { get; set; }

    [Display(Name = "Naam")]
    public string VolledigeNaam { get; set; }

    [Display(Name = "Gebruikersnaam")]
    public string UserName { get; set; }

    [Display(Name = "E-mail")]
    public string Email { get; set; }
    public bool IsAdmin { get; set; }

    public GroupSelectList GroupSelect { get; set; }

    public List<UserRole> Roles { get; set; } = new();
    public List<GroupUser> Groups { get; set; } = new();

}
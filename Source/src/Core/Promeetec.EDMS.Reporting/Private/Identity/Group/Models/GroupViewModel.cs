using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

public class GroupViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Naam")]
    public string Name { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Omschrijving")]
    public string Description { get; set; }

    public Status Status { get; set; }

    [Display(Name = "Aantal rollen")]
    public int AantalRollen { get; set; }


    [Display(Name = "Aantal gebruikers")]
    public int AantalGebruikers { get; set; }

    public IEnumerable<string> RoleNames { get; set; } = new List<string>();
    public IEnumerable<string> MedewerkerNames { get; set; } = new List<string>();
}
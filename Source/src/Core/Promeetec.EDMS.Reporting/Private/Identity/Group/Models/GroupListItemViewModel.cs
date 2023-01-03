using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

public class GroupListItemViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Naam")]
    public string Name { get; set; }


    [Display(Name = "Omschrijving")]
    public string Description { get; set; }


    [Display(Name = "Aantal rollen")]
    public int AantalRollen { get; set; }


    [Display(Name = "Aantal gebruikers")]
    public int AantalGebruikers { get; set; }

    public Status Status { get; set; }
}
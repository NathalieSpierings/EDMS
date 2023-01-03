using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

public class RoleListItemViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Naam")]
    public string Name { get; set; }


    [Display(Name = "Omschrijving")]
    public string Description { get; set; }

    public RoleType RoleType { get; set; }


    [Display(Name = "Aantal groepen")]
    public int AantalGroepen { get; set; }


    [Display(Name = "Aantal gebruikers")]
    public int AantalGebruikers { get; set; }

    public Status Status { get; set; }
}
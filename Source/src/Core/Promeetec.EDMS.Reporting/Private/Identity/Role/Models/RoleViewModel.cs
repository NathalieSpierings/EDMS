using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

public class RoleViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Naam")]
    public string Name { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Omschrijving")]
    public string Description { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }


    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoor { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }


    [Display(Name = "Aangepast door")]
    public string AangepastDoor { get; set; }


    [Display(Name = "Status")]
    [Required(ErrorMessage = "Status is verplicht.")]
    public Status Status { get; set; }


    [Display(Name = "Rol soort")]
    public RoleType RoleType { get; set; }


    [Display(Name = "Aantal groepen")]
    public int AantalGroepen { get; set; }


    [Display(Name = "Aantal gebruikers")]
    public int AantalGebruikers { get; set; }


    public List<GroupRole> Groups { get; set; } = new();

    public IEnumerable<string> GroupNames { get; set; } = new List<string>();
    public IEnumerable<string> MedewerkerNames { get; set; } = new List<string>();
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

public class IONZoekopdrachtViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public Guid MedewerkerId { get; set; }


    [Display(Name = "Periode")]
    [Required(ErrorMessage = "Periode is verplicht.")]
    public string Periode { get; set; }


    [Display(Name = "AGB-code zorgverlener")]
    [Required(ErrorMessage = "AGB-code zorgverlener is verplicht.")]
    public string AgbCodeZorgverlener { get; set; }


    [Display(Name = "AGB-code praktijk")]
    [Required(ErrorMessage = "AGB-code praktijk is verplicht.")]
    public string AgbCodeOnderneming { get; set; }


    [Required(ErrorMessage = "Patientrelaties zoekoptie is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecteer een patientrelatie zoekoptie.")]
    [Display(Name = "Patientrelaties zoekoptie")]
    public IONZoekOptie ZoekOptie { get; set; }

    public SelectList AgbCodesZorgverlener { get; set; }

    [Display(Name = "Periode")]
    public SelectList Periodes { get; set; }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

public class RapportageCreateViewModel : BestandCreateViewModel
{
    [Display(Name = "Referentie")]
    [Required(ErrorMessage = "Referentie is verplicht.")]
    public string ReferentiePromeetec { get; set; }

    [Display(Name = "Rapportage soort")]
    [Required(ErrorMessage = "Rapportage soort is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecteer een rapportage soort.")]
    public RapportageSoort RapportageSoort { get; set; }

    public Guid OrganisatieId { get; set; }
    public FilesViewModel Files { get; set; } = new();

    [Display(Name = "Eigenaar")]
    public Guid? RapportageEigenaarId { get; set; }

    public SelectList RapportageEigenaren { get; set; }
}
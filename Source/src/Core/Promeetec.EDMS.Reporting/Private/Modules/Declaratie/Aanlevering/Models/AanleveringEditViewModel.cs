using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringEditViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Uw referentie")]
    [Required(ErrorMessage = "Uw referentie is verplicht.")]
    [StringLength(50, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 1)]
    public string Referentie { get; set; }


    [Display(Name = "Referentie Promeetec")]
    [StringLength(50, ErrorMessage = "{0} mag maximaal {1} tekens bevatten.")]
    public string ReferentiePromeetec { get; set; }

    [Display(Name = "Aanleverstatus")]
    public AanleverStatus AanleverStatus { get; set; }

    [Display(Name = "Behandelaar")]
    [Required(ErrorMessage = "Behandelaar is verplicht.")]
    public Guid? BehandelaarId { get; set; }

    public MedewerkerViewModel Behandelaar { get; set; }

    [Display(Name = "Behandelaar")]
    public SelectList Behandelaren { get; set; }

    [AllowHtml]
    [Display(Name = "Opmerking")]
    [DataType(DataType.MultilineText)]
    [StringLength(4000, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 0)]
    public string Opmerking { get; set; }

    [Display(Name = "Toevoegen documenten")]
    public bool ToevoegenBestand { get; set; }




    [Display(Name = "Eigenaar")]
    [Required(ErrorMessage = "Eigenaar is verplicht.")]
    public Guid EigenaarId { get; set; }

    public SelectList Eigenaren { get; set; }

    public MedewerkerViewModel Eigenaar { get; set; }









    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }

    public Guid? AangepastDoor { get; set; }


}
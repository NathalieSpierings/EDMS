using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.WeegMoment.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

public class EditIntakeViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid VerzekerdeId { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Intake datum")]
    [Required(ErrorMessage = "Intake datum is verplicht.")]
    public DateTime IntakeDatum { get; set; }

    [AllowHtml]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Bijzonderheden (niet medisch)")]
    public string Opmerking { get; set; }


    public WeegMomentCreateViewModel WeegMoment { get; set; }


    [Display(Name = "Cliënt")]
    public VerzekerdeViewModel Verzekerde { get; set; }


    [Display(Name = "Behandelaar")]
    [Required(ErrorMessage = "Behandelaar is verplicht.")]
    public Guid BehandelaarId { get; set; }

    public MedewerkerViewModel Behandelaar { get; set; }

    [Display(Name = "Behandelaar")]
    public SelectList Behandelaren { get; set; }
}
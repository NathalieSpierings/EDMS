using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

public class StartBehandelplanViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid IntakeId { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Intakedatum { get; set; }


    [IsDateAfter("Intakedatum", true, ErrorMessage = "Startdatum kan niet voor de intakedatum liggen!")]
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Startdatum")]
    [Required(ErrorMessage = "Startdatum is verplicht.")]
    public DateTime Startdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Einddatum")]
    public DateTime Einddatum { get; set; }


    [Display(Name = "Programma")]
    [Required(ErrorMessage = "Programma is verplicht.")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecteer een programma.")]
    public GliProgramma GliProgramma { get; set; }


    [Display(Name = "Behandelfase")]
    public GliBehandelfase Fase { get; set; }


    [AllowHtml]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Bijzonderheden (niet medisch)")]
    public string Opmerking { get; set; }



    [Display(Name = "Cliënt")]
    public VerzekerdeViewModel Verzekerde { get; set; }


    [Display(Name = "Behandelaar")]
    public MedewerkerViewModel Behandelaar { get; set; }
}
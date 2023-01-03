using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

public class BehandelplanViewModel : ModelBase
{
    public Guid Id { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Startdatum")]
    public DateTime Startdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Einddatum")]
    public DateTime Einddatum { get; set; }


    [Display(Name = "Programma")]
    public GliProgramma GliProgramma { get; set; }


    [Display(Name = "Behandelfase")]
    public GliBehandelfase Fase { get; set; }

    public GliStatus Status { get; set; }

    [AllowHtml]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Bijzonderheden (niet medisch)")]
    public string Opmerking { get; set; }


    [Display(Name = "Voortijdig beëindigd")]
    public bool VoortijdigGestopt { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Voortijdige beëindiging datum")]
    public DateTime? VoortijdigeStopdatum { get; set; }


    [Display(Name = "Verwerkt")]
    public bool Verwerkt { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Verwerkt op")]
    public DateTime? VerwerktOp { get; set; }
}
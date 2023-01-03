using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.WeegMoment.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

public class GliIntakeViewModel : ModelBase
{
    public Guid Id { get; set; }

    public OrganisatieViewModel Organisatie { get; set; }

    public Guid VerzekerdeId { get; set; }

    [Display(Name = "Burgerservicenummer")]
    public string Bsn { get; set; }

    [Display(Name = "AGB-code verwijzer")]
    public string AgbCodeVerwijzer { get; set; }


    [Display(Name = "Naam verwijzer")]
    public string NaamVerwijzer { get; set; }

    public double? Lengte { get; set; }

    [Display(Name = "Cliënt")]
    public string Client { get; set; }

    public GliStatus Status { get; set; }

    public IEnumerable<WeegMomentViewModel> WeegMomenten { get; set; } = new List<WeegMomentViewModel>();

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Intake datum")]
    public DateTime IntakeDatum { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Bijzonderheden (niet medisch)")]
    public string Opmerking { get; set; }


    public Guid BehandelaarId { get; set; }

    [Display(Name = "Behandelaar")]
    public string Behandelaar { get; set; }


    [Display(Name = "Verwerkt")]
    public bool Verwerkt { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Verwerkt op")]
    public DateTime? VerwerktOp { get; set; }

    public IEnumerable<BehandelplanViewModel> Behandelplannen { get; set; } = new List<BehandelplanViewModel>();
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

public class StopBehandelplanViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid IntakeId { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Intakedatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Startdatum { get; set; }


    [IsDateAfter("Startdatum", true, ErrorMessage = "Voortijdige stopdatum kan niet voor de startdatum liggen!")]
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Voortijdige stopdatum")]
    [Required(ErrorMessage = "Voortijdige stopdatum is verplicht.")]
    public DateTime VoortijdigeStopdatum { get; set; }

    public bool VoortijdigGestopt { get; set; }
    public GliBehandelfase Fase { get; set; }
    public GliProgramma GliProgramma { get; set; }
    public GliStatus GliStatus { get; set; }

    [AllowHtml]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Bijzonderheden (niet medisch)")]
    public string Opmerking { get; set; }



    public VerzekerdeViewModel Verzekerde { get; set; }
    public MedewerkerViewModel Behandelaar { get; set; }


    [Display(Name = "Rede einde zorg")]
    [Required(ErrorMessage = "Rede einde zorg is verplicht.")]
    public Guid RedenEindeZorgId { get; set; }

    public SelectList RedenenEindeZorg { get; set; }
    public RedenEindeZorgViewModel RedenEindeZorg { get; set; }
}
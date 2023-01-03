using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

public class MachtigingRegistratieCreateViewModel : ModelBase
{
    public MachtigingViewModel Machtiging { get; set; }

    public bool NewRegistratiesAllowed { get; set; }
    public DateTime MachtigingStartDatum { get; set; }
    public DateTime? MachtigingEindDatum { get; set; }
    public int MaxRegistrationRetroPeriodDays { get; set; }
    public DateTime RegistrationRetroPeriodDaysDate => DateTime.Today.AddDays(-MaxRegistrationRetroPeriodDays);
    public DateTime Today => DateTime.Today;

    [IsKetenzorgBehandeldatumAfterToday("Today", true, ErrorMessage = "Behandeldatum mag niet in de toekomst liggen!")]
    [IsKetenzorgBehandeldatumBeforeDays("RegistrationRetroPeriodDaysDate", true, ErrorMessage = "Gekozen behandeldatum is niet toegestaan!")]
    [IsKetenzorgBehandeldatumBeforeMachtigingStartdatum("MachtigingStartDatum", true, ErrorMessage = "Behandeldatum kan niet voor de machtiging startdatum liggen!")]
    [IsKetenzorgBehandeldatumAfterMachtigingStartdatum("MachtigingEindDatum", true, ErrorMessage = "Behandeldatum kan niet na de machtiging einddatum liggen!")]
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "Behandeldatum is verplicht.")]
    [Display(Name = "Behandeldatum")]
    public DateTime Behandeldatum { get; set; }


    public int MaxAantal { get; set; }
    public int ResterendAantal { get; set; }

    [Required(ErrorMessage = "Aantal is verplicht.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Alleen hele positieve getallen zijn toegestaan")]
    [Range(1, int.MaxValue, ErrorMessage = "Aantal mag niet negatief zijn!")]
    [DisplayFormat(DataFormatString = "{0:#}", ApplyFormatInEditMode = true)]
    [IsLessThan("ResterendAantal", true, ErrorMessage = "Aantal overschrijdt het maximum!")]
    public int Aantal { get; set; }

    public List<MachtigingProductActiviteitViewModel> Activiteiten { get; set; }


    [Display(Name = "Zorgactiviteit")]
    [Required(ErrorMessage = "Zorgactiviteit is verplicht.")]
    public Guid ActiviteitId { get; set; }
    public SelectList SelectListActiviteiten { get; set; }
}
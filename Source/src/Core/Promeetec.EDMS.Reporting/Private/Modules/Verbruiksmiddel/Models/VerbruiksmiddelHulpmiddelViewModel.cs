using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

public class VerbruiksmiddelHulpmiddelViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Z-index nummer")]
    public int? ZIndex { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Prestatie datum")]
    public DateTime? PrestatieDatum { get; set; }

    public int? Hoeveelheid { get; set; }
}
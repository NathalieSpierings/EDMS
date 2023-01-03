using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

public class ZorgprofielViewModel : ModelBase
{
    [DisplayName("Profiel")]
    public ProfielCode? ProfielCode { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Profiel startdatum")]
    [RequiredIfZorgprofielIsNotGeenValidator(ErrorMessage = "Als je een profiel kiest moet u een profiel startdatum invoeren.")]
    public DateTime? ProfielStartdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Profiel einddatum")]
    [RequiredIfZorgprofielIsGeenValidator(ErrorMessage = "Als u voor profiel 'Geen' kiest moet u een profiel einddatum invoeren.")]
    public DateTime? ProfielEinddatum { get; set; }
}
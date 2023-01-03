using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieRetrictViewModel : ModelBase
{
    [UIHint("Boolean")]
    [DefaultValue(false)]
    public bool Beperkt { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Beperkt op")]
    public DateTime? BeperktOp { get; set; }


    [StringLength(450, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string BeperktReden { get; set; }
}
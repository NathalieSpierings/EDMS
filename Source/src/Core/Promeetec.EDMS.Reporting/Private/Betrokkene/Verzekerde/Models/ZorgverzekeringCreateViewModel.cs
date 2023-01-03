using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class ZorgverzekeringCreateViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Verzekerdenummer")]
    [StringLength(15, ErrorMessage = "{0} bestaat uit maximaal {1} tekens.")]
    public string VerzekerdeNummer { get; set; }

    [Display(Name = "Patientnummer")]
    [StringLength(11, ErrorMessage = "{0} bestaat uit {1} tekens.")]
    public string PatientNummer { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    public DateTime VerzekerdOp { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    public DateTime? VerzekerdTot { get; set; }


    [Display(Name = "Verzekeraar")]
    [Required(ErrorMessage = "Verzekeraar is verplicht.")]
    public Guid VerzekeraarId { get; set; }

    [Display(Name = "Verzekeraar")]
    public SelectList Verzekeraars { get; set; }
}
using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Systeem.Models;

public class MaintenanceViewModel : ModelBase
{
    public AanleveringenOpschonenViewModel AanleveringenOpschonen { get; set; }
    public ExceptionsOpschonenViewModel ExceptionsOpschonen { get; set; }
}


public class AanleveringenOpschonenViewModel : ModelBase
{
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    public DateTime Startdatum { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    public DateTime Einddatum { get; set; }
}

public class ExceptionsOpschonenViewModel : ModelBase
{
    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    public DateTime Startdatum { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Required(ErrorMessage = "{0} is verplicht.")]
    public DateTime Einddatum { get; set; }
}
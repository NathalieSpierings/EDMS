using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Message.Models;

public class MessageCreateEdotViewModel : ModelBase
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    [Display(Name = "Memo")]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Datum")]
    public DateTime Date { get; set; }

    public bool IsPrivate { get; set; }

}
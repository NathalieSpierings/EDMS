using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.Models;

public class MemosViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public Guid MedewerkerId { get; set; }

    public MemoViewModel Memo { get; set; }
    public IQueryable<MemoViewModel> Memos { get; set; }
}

public class MemoViewModel : ModelBase
{
    public Guid Id { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date, ErrorMessage = "Dit is geen geldige datum!")]
    [RegularExpression(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$", ErrorMessage = "Dit is geen geldige datum!")]
    [Display(Name = "Datum")]
    public DateTime Date { get; set; }


    [Display(Name = "Memo")]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; }
}
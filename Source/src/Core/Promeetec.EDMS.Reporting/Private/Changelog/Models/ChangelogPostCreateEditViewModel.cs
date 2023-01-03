using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Changelog.Models;

public class ChangelogPostCreateEditViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Datum"), UIHint("Date"), DataType(DataType.Date)]
    public DateTime Date { get; set; }


    [Display(Name = "Titel"),
     Required(ErrorMessage = "{0} is verplicht."),
     StringLength(200, ErrorMessage = "{0} moet minimaal {2} en maximaal {1} tekens bevatten.", MinimumLength = 1)]
    public string Title { get; set; }


    [Display(Name = "Korte omschrijving"),
     UIHint("MultilineText"),
     Required(ErrorMessage = "{0} is verplicht."),
     StringLength(450, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Description { get; set; }


    [Display(Name = "Post"), UIHint("MultilineText"),
     Required(ErrorMessage = "{0} is verplicht.")]
    public string Content { get; set; }


    public ChangeLogType Type { get; set; }

    [StringLength(128)]
    public string Tag { get; set; }
}
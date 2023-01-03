using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Changelog.Models;

public class ChangelogPostViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Datum"), UIHint("Date"), DataType(DataType.Date)]
    public DateTime Date { get; set; }


    [Display(Name = "Titel")]
    public string Title { get; set; }


    [Display(Name = "Korte omschrijving")]
    public string Description { get; set; }


    [Display(Name = "Post")]
    public string Content { get; set; }

    public ChangeLogType Type { get; set; }

    public string Tag { get; set; }
}
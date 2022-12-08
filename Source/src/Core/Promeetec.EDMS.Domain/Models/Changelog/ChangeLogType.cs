using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Changelog;

public enum ChangeLogType
{
    [Display(Name = "Nieuw")]
    New,

    [Display(Name = "Functie")]
    Feature,

    [Display(Name = "Verbetering")]
    Improvement
}
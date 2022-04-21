using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

public enum ProfielCode
{
    Geen = 0,

    [Display(Name = "Profiel 0")]
    ProfielCode0 = 1,

    [Display(Name = "Profiel 1")]
    ProfielCode1 = 2,

    [Display(Name = "Profiel 2")]
    ProfielCode2 = 3,

    [Display(Name = "Profiel 3")]
    ProfielCode3 = 4,

    [Display(Name = "Profiel 4")]
    ProfielCode4 = 5,

    [Display(Name = "Profiel 5")]
    ProfielCode5 = 6,

    [Display(Name = "Profiel 6")]
    ProfielCode6 = 7,

    [Display(Name = "Profiel 7")]
    ProfielCode7 = 8
}

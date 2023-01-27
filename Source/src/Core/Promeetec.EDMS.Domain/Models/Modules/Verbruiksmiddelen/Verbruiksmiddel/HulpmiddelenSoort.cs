using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;

public enum HulpmiddelenSoort
{
    Onbekend = 0,
    Profiel = 1,

    [Display(Name = "Overige hulpmiddelen")]
    Overige = 2
}

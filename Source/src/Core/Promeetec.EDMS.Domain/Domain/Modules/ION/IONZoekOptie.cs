using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Modules.ION;

public enum IONZoekOptie
{
    [Display(Name = "Niet gespecificeerd")]
    Onbekend = 0,

    [Display(Name = "Zoeken op zorgverlener")]
    ZoekenOpZorgverlener = 1,

    [Display(Name = "Zoeken op praktijk")]
    ZoekenOpPraktijk = 2,

    [Display(Name = "Zoeken op praktijk en gekoppelde zorgverleners")]
    ZoekenOpPraktijkEnGekoppeldeZorgverleners = 3
}
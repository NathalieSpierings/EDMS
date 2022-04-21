using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

public enum Geslacht
{
    Onbekend = 1,
    Mannelijk = 2,
    Vrouwelijk = 3,

    [Display(Name = "Niet gespecifieerd")]
    NietGespecificeerd = 4
}

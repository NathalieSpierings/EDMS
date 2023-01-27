using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;

public enum AanleverStatusNaSchrijvenAanleverbestanden
{
    [Display(Name = "Niet gespecificeerd")]
    Onbekend = 0,

    [Display(Name = "In behandeling")]
    InBehandeling = 2,

    Verwerkt = 4,
}
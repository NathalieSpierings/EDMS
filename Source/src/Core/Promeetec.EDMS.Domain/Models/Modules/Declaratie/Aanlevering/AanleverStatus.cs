using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

public enum AanleverStatus
{
    Aangemaakt = 1,

    [Display(Name = "In behandeling")]
    InBehandeling = 2,

    Ingediend = 3,
    Verwerkt = 4,
    Afgekeurd = 5
}
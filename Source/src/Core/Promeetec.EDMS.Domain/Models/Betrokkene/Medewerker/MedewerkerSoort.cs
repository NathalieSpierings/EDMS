using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

public enum MedewerkerSoort
{
    Onbekend = 0,

    [Display(Name = "Promeetec medewerker")]
    Intern = 1,

    [Display(Name = "Externe medewerker")]
    Extern = 2,

    [Display(Name = "Promeetec privilege medewerker")]
    Privilege = 3
}
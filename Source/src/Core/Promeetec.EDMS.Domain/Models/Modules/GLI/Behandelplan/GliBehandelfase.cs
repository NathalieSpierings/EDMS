using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;

public enum GliBehandelfase
{
    [Display(Name = "Behandelfase 1")]
    Behandelfase1 = 1,

    [Display(Name = "Behandelfase 2")]
    Behandelfase2 = 2,

    [Display(Name = "Behandelfase 3")]
    Behandelfase3 = 3,

    [Display(Name = "Behandelfase 4")]
    Behandelfase4 = 4,

    [Display(Name = "Onderhoudsfase 1")]
    Onderhoudsfase1 = 5,

    [Display(Name = "Onderhoudsfase 2")]
    Onderhoudsfase2 = 6,

    [Display(Name = "Onderhoudsfase 3")]
    Onderhoudsfase3 = 7,

    [Display(Name = "Onderhoudsfase 4")]
    Onderhoudsfase4 = 8,
}
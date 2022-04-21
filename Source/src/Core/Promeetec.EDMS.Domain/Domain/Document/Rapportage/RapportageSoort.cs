using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Document.Rapportage;

public enum RapportageSoort
{
    Declaratie = 1,

    [Display(Name = "GLI registratie")]
    GliRegistratie = 2,

    [Display(Name = "Verbruiksmiddel prestatie")]
    VerbruiksmiddelPrestatie = 3
}
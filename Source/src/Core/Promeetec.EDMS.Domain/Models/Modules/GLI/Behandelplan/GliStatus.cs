using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;

public enum GliStatus
{
    [Display(Name = "Nog niet gestart")]
    NogNietGestart = 0,
    Gestart = 1,
    Gestopt = 2,
    Afgerond = 3,
    Verwijderd = 4,
}
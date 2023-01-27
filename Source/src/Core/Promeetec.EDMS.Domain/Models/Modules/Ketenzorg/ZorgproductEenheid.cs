using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Ketenzorg;

public enum ZorgproductEenheid
{
    [Display(Name = "Minuten")]
    Minutes,

    [Display(Name = "Consult")]
    Piece
}
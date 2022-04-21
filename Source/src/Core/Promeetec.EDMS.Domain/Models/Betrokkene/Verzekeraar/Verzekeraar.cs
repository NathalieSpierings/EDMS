using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;

public class Verzekeraar : AggregateRoot
{
    /// <summary>
    /// The uzovi of the insurer.
    /// </summary>
    [Required]
    public short Uzovi { get; set; }


    /// <summary>
    /// The name of the insurer.
    /// </summary>
    [Required, MaxLength(256)]
    public string Naam { get; set; }


    /// <summary>
    /// Indicator if the insurer is active or not.
    /// </summary>
    public bool Actief { get; set; }


    /// <summary>
    /// Creates an empty insurer.
    /// </summary>
    public Verzekeraar()
    {

    }
}

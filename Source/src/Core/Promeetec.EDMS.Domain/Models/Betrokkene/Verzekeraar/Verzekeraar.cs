using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Commands;

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

    /// <summary>
    /// Creates a verzekeraar.
    /// </summary>
    /// <param name="cmd">The create verzekeraar command.</param>
    public Verzekeraar(CreateVerzekeraar cmd)
    {
        Id = cmd.Id;
        Uzovi = cmd.Uzovi;
        Naam = cmd.Naam;
        Actief = cmd.Actief;
    }
}

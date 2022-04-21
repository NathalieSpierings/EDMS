using OpenCqrs.Domain;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekeraar;

public class Verzekeraar : AggregateRoot
{
    /// <summary>
    /// The uzovi of the insurer.
    /// </summary>
    public short Uzovi { get; set; }


    /// <summary>
    /// The name of the insurer.
    /// </summary>
    [StringLength(256)]
    public string Naam { get; set; }


    /// <summary>
    /// Indicator if the insurer is active or not.
    /// </summary>
    public bool Actief { get; set; }


    public Verzekeraar() { }
}

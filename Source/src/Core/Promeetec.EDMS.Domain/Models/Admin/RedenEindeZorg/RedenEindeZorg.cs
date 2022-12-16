using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;

public class RedenEindeZorg : AggregateRoot
{
    /// <summary>
    /// The code for the reden einde zorg.
    /// </summary>
    [Required, MaxLength(2)]
    public string Code { get; set; }

    /// <summary>
    /// The description for the reden einde zorg.
    /// </summary>
    [MaxLength(450)]
    public string? Omschrijving { get; set; }


    /// <summary>
    /// The status of the reden einde zorg.
    /// </summary>
    public Shared.Status Status { get; set; }


    /// <summary>
    /// Creates an empty reden einde zorg.
    /// </summary>
    public RedenEindeZorg()
    {
    }
}

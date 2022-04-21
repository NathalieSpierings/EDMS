using System.ComponentModel.DataAnnotations;
using OpenCqrs.Domain;

namespace Promeetec.EDMS.Domain.Domain.Admin.RedenEindeZorg;

public class RedenEindeZorg : AggregateRoot
{
    /// <summary>
    /// The code for the reden einde zorg.
    /// </summary>
    [Required, StringLength(2)]
    public string Code { get; set; }


    /// <summary>
    /// The description for the reden einde zorg.
    /// </summary>
    [StringLength(450)]
    public string Omschrijving { get; set; }


    /// <summary>
    /// The status of the reden einde zorg.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: RedenEindeZorg is not available.</description>
    /// </item>
    /// <item>
    /// <description>Actief: RedenEindeZorg is available.</description>
    /// </item>
    /// <item>
    /// <description>Verwijderd: RedenEindeZorg is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Shared.Status Status { get; set; }
}

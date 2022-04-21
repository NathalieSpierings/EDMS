using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Admin.Zorgstraat;

public class Zorgstraat : AggregateRoot
{
    /// <summary>
    /// The name of the zorgstraat.
    /// </summary>
    [Required, StringLength(200)]
    public string Naam { get; set; }


    /// <summary>
    /// The status of the zorgstraat.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: Zorgstraat is not available.</description>
    /// </item>
    /// <item>
    /// <description>Actief: Zorgstraat is available.</description>
    /// </item>
    /// <item>
    /// <description>Verwijderd: Zorgstraat is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; set; }

    public Zorgstraat() { }
}

using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Land;

public class Land : AggregateRoot
{
    /// <summary>
    /// The culture code of the country.
    /// </summary>
    [MaxLength(50)]
    public string CultureCode { get; set; }


    /// <summary>
    /// The native name of the country.
    /// </summary>
    [Required]
    [MaxLength(128)]
    public string NativeName { get; set; }


    /// <summary>
    /// The status of the country.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: Country is not available.</description>
    /// </item>
    /// <item>
    /// <description>Actief: Country is available.</description>
    /// </item>
    /// <item>
    /// <description>Verwijderd: Country is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; set; }

    public Land() { }
}

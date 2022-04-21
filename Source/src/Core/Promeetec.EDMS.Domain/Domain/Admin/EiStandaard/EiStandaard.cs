using System.ComponentModel.DataAnnotations;
using OpenCqrs.Domain;

namespace Promeetec.EDMS.Domain.Domain.Admin.EiStandaard;

public class EiStandaard : AggregateRoot
{
    /// <summary>
    /// The name of the EI-standaard.
    /// </summary>
    [StringLength(128)]
    public string Naam { get; set; }


    /// <summary>
    /// The EI bericht codes of the EI-standaard.
    /// </summary>
    [StringLength(50)]
    public string EiBerichtCodes { get; set; }

    /// <summary>
    /// The version of the EI-standaard.
    /// </summary>
    public int? Versie { get; set; }


    /// <summary>
    /// The subversion of the EI-standaard.
    /// </summary>
    public int? SubVersie { get; set; }

    /// <summary>
    /// The code of the EI-standaard.
    /// </summary>
    [Required, StringLength(128)]
    public string Code { get; set; }

    /// <summary>
    /// The description of the EI-standaard.
    /// </summary>
    [StringLength(200)]
    public string Omschrijving { get; set; }

    public EiStandaard() { }
}
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Admin.EiStandaard;

public class EiStandaard : AggregateRoot
{
    /// <summary>
    /// The name of the EI-standaard.
    /// </summary>
    [MaxLength(128)]
    public string Naam { get; set; }


    /// <summary>
    /// The EI bericht codes of the EI-standaard.
    /// </summary>
    [MaxLength(50)]
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
    [MaxLength(200)]
    public string Omschrijving { get; set; }


    /// <summary>
    /// Creates an empty EI-standaard.
    /// </summary>
    public EiStandaard()
    {
    }
}
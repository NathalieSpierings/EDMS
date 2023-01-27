using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

public class Zorgprofiel : AggregateRoot
{
    /// <summary>
    /// The code of the profiel.
    /// </summary>
    [Required]
    public ProfielCode ProfielCode { get; set; }

    /// <summary>
    /// The start date of the profiel.
    /// </summary>
    [Required]
    public DateTime ProfielStartdatum { get; set; }

    /// <summary>
    /// The optional end date of the profiel.
    /// </summary>
    public DateTime? ProfielEinddatum { get; set; }


    #region Navigation properties

    public virtual ICollection<VerzekerdeToZorgprofiel> Verzekerden { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty zorgprofiel.
    /// </summary>
    public Zorgprofiel()
    {
    }
}

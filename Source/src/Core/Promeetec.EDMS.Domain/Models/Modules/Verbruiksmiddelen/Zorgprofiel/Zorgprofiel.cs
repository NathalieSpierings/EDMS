using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

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
    [Required, Column(TypeName = "datetime2")]
    public DateTime ProfielStartdatum { get; set; }

    /// <summary>
    /// The optional end date of the profiel.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ProfielEinddatum { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


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

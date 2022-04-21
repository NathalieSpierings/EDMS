using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

public class Zorgprofiel : AggregateRoot
{
    /// <summary>
    /// The profiel code.
    /// </summary>
    public ProfielCode ProfielCode { get; set; }


    /// <summary>
    /// The start date of the profiel.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime ProfielStartdatum { get; set; }


    /// <summary>
    /// The end date of the profiel.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ProfielEinddatum { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    public virtual ICollection<VerzekerdeToZorgprofiel> Verzekerden { get; set; } = new List<VerzekerdeToZorgprofiel>();

}

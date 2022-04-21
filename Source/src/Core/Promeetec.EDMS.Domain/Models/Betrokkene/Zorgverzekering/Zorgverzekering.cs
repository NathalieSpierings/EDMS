using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;

public class Zorgverzekering : AggregateRoot
{
    /// <summary>
    /// The health insurance number.
    /// </summary>
    [MaxLength(15)]
    public string VerzekerdeNummer { get; set; }


    /// <summary>
    /// The patient number.
    /// </summary>
    [MaxLength(11)]
    public string PatientNummer { get; set; }


    /// <summary>
    /// The insured on date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime VerzekerdOp { get; set; }

    /// <summary>
    /// The insured until date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? VerzekerdTot { get; set; }


    #region Navigation properties
    
    public Guid VerzekeraarId { get; set; }
    public virtual Verzekeraar.Verzekeraar Verzekeraar { get; set; }

    public virtual ICollection<VerzekerdeToZorgverzekering> Verzekerden { get; set; }


    #endregion


    /// <summary>
    /// Creates an empty health care insurance.
    /// </summary>
    public Zorgverzekering()
    {
    }
}

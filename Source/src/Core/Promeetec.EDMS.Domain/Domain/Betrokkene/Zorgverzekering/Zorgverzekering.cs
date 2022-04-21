using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Zorgverzekering;

public class Zorgverzekering : AggregateRoot
{
    /// <summary>
    /// The health insurance number.
    /// </summary>
    [StringLength(15)]
    public string VerzekerdeNummer { get; set; }


    /// <summary>
    /// The patient number.
    /// </summary>
    [StringLength(11)]
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

    /// <summary>
    /// The unique identifier of the verzekeraar for the zorgverzekering.
    /// </summary>
    public Guid VerzekeraarId { get; set; }


    /// <summary>
    /// Reference to the verzekeraar for the zorgverzekering.
    /// </summary>
    public Verzekeraar.Verzekeraar Verzekeraar { get; set; }

    public ICollection<VerzekerdeToZorgverzekering> Verzekerden { get; set; } = new List<VerzekerdeToZorgverzekering>();


    #endregion
}

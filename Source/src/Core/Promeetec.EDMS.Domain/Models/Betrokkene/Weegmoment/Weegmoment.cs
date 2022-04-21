using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Weegmoment;

public class Weegmoment : AggregateRoot
{
    /// <summary>
    /// The weight of the insured person for this weight moment.
    /// </summary>
    [Required]
    public double Gewicht { get; set; }

    /// <summary>
    /// The weight date for this weight moment.
    /// </summary>
    [Required]
    public DateTime Opnamedatum { get; set; }


    #region Navigation properties

    public Guid? VerzekerdeId { get; set; }
    public virtual Verzekerde.Verzekerde Verzekerde { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty weight moment.
    /// </summary>
    public Weegmoment()
    {
    }
}
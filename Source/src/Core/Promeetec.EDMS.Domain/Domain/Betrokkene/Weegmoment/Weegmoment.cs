using OpenCqrs.Domain;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Weegmoment;

public class Weegmoment : AggregateRoot
{
    /// <summary>
    /// The weight of the insured person for this weegmoment.
    /// </summary>
    public double Gewicht { get; set; }

    /// <summary>
    /// The weight date for this weegmoment.
    /// </summary>
    public DateTime Opnamedatum { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the insured person for the weegmoment.
    /// </summary>
    public Guid? VerzekerdeId { get; set; }

    /// <summary>
    /// Reference to the verzekerde for the weegmoment.
    /// </summary>
    public Verzekerde.Verzekerde Verzekerde { get; set; }

    #endregion

    public Weegmoment() { }
}
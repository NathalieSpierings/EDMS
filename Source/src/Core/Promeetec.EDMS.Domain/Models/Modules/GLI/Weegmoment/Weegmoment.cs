using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment;

public class Weegmoment : AggregateRoot
{
    /// <summary>
    /// The weight of the insured person.
    /// </summary>
    public double Gewicht { get; set; }

    /// <summary>
    /// The date of the weight moment.
    /// </summary>
    public DateTime Opnamedatum { get; set; }


    #region Navigation Properties

    /// <summary>
    /// The unique identifier of the insured person for the weegmoment.
    /// </summary>
    public Guid? VerzekerdeId { get; set; }


    /// <summary>
    /// Reference to the insured person for the weegmoment.
    /// </summary>
    public virtual Betrokkene.Verzekerde.Verzekerde Verzekerde { get; set; }

    #endregion

    /// <summary>
    /// Creates an empty weegmoment.
    /// </summary>
    public Weegmoment() { }


    /// <summary>
    /// Creates a weegmoment.
    /// </summary>
    /// <param name="cmd">The create weegmoment command.</param>
    public Weegmoment(CreateWeegmoment cmd)
    {
        Id = cmd.Id;

        VerzekerdeId = cmd.VerzekerdeId;
        Gewicht = cmd.Gewicht;
        Opnamedatum = cmd.Opnamedatum;

        //AddAndApplyEvent(new WeegMomentToegevoegd
        //{
        //    AggregateRootId = cmd.AggregateRootId,
        //    UserId = cmd.UserId,
        //    UserDisplayName = cmd.UserDisplayName,

        //    Lengte = $"{cmd.Lengte} cm",
        //    Gewicht = $"{cmd.Gewicht} KG",
        //    Opnamedatum = cmd.Opnamedatum.ToString("dd-MM-yyyy")
        //});
    }
}
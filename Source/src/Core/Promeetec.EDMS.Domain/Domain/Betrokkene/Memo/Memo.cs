using OpenCqrs.Domain;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Memo;

public class Memo : AggregateRoot
{
    /// <summary>
    /// The memo creation date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The memo content.
    /// </summary>
    public string Content { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the medewerker for the memo.
    /// </summary>
    public Guid MedewerkerId { get; set; }


    /// <summary>
    /// Reference to the medewerker for the momo.
    /// </summary>
    public Medewerker.Medewerker Medewerker { get; set; }


    #endregion
}

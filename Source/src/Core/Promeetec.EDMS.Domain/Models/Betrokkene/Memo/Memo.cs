using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Memo;

public class Memo : AggregateRoot
{
    /// <summary>
    /// The memo creation date.
    /// </summary>
    [Required]
    public DateTime Date { get; set; }

    /// <summary>
    /// The memo content.
    /// </summary>
    [Required]
    public string Content { get; set; }


    #region Navigation properties

    public Guid MedewerkerId { get; set; }
    public virtual Medewerker.Medewerker Medewerker { get; set; }


    #endregion


    /// <summary>
    /// Creates an empty memo.
    /// </summary>
    public Memo()
    {

    }

    /// <summary>
    /// Creates a memo.
    /// </summary>
    /// <param name="cmd">The create memo command.</param>
    public Memo(CreateMemo cmd)
    {
        Id = cmd.Id;

        MedewerkerId = cmd.MedewerkerId;
        Date = cmd.Date;
        Content = cmd.Content;
    }
}

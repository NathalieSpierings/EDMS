using System.ComponentModel.DataAnnotations;

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

    //public Memo(CreateMemo cmd)
    //{
    //    MedewerkerId = cmd.MedewerkerId;
    //    Date = cmd.Date;
    //    Content = cmd.Content;
    //}

    //#region Navigation properties

    ///// <summary>
    ///// The unique identifier of the medewerker for the memo.
    ///// </summary>
    //public Guid MedewerkerId { get; set; }


    ///// <summary>
    ///// Reference to the medewerker for the momo.
    ///// </summary>
    //public Medewerker.Medewerker Medewerker { get; set; }


    //#endregion
}

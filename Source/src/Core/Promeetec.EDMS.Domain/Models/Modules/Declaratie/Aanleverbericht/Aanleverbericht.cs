using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;

public class Aanleverbericht : AggregateRoot
{
    /// <summary>
    /// The subject of the aanleverbericht.
    /// </summary>
    [MaxLength(450)]
    public string Onderwerp { get; set; }

    /// <summary>
    /// The message of the aanleverbericht.
    /// </summary>
    [Required, MaxLength(10000)]
    public string Bericht { get; set; }

    /// <summary>
    /// The sort order of the aanleverbericht.
    /// </summary>
    [Required]
    public int Volgorde { get; set; }

    /// <summary>
    /// Indicator if the aanleverbericht is readed yes or no.
    /// </summary>
    public bool Gelezen { get; set; }

    /// <summary>
    /// The placement date of the aanleverbericht.
    /// </summary>
    [Required]
    public DateTime GeplaatstOp { get; set; }

    /// <summary>
    /// The last readed date of the aanleverbericht.
    /// </summary>
    public DateTime? LaastGelezenOp { get; set; }

    /// <summary>
    /// The status of the aanleverbericht.
    /// </summary>
    public AanleverberichtStatus AanleverberichtStatus { get; set; }


    #region Navigation properties

    public Guid? LaatsteLezerId { get; set; }
    public virtual Medewerker LaatsteLezer { get; set; }

    public Guid OntvangerId { get; set; }
    public virtual Medewerker Ontvanger { get; set; }

    public Guid AfzenderId { get; set; }
    public virtual Medewerker Afzender { get; set; }

    public Guid? ParentId { get; set; }
    public virtual Aanleverbericht Parent { get; set; }

    public Guid AanleveringId { get; set; }
    public virtual Aanlevering.Aanlevering Aanlevering { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty aanleverbericht.
    /// </summary>
    public Aanleverbericht()
    {

    }

    /// <summary>
    /// Creates an aanleverbericht.
    /// </summary>
    /// <param name="cmd">The create aanleverbericht command.</param>
    /// <param name="sortOrder">The sortorder.</param>
    public Aanleverbericht(CreateAanleverbericht cmd, int sortOrder)
    {
        Id = cmd.Id;

        Volgorde = sortOrder;
        AanleverberichtStatus = AanleverberichtStatus.Open;
        GeplaatstOp = DateTime.Now;
        Onderwerp = cmd.Onderwerp;
        Bericht = cmd.Bericht;
        Gelezen = false;
        ParentId = cmd.ParentId;
        AfzenderId = cmd.AfzenderId;
        OntvangerId = cmd.OntvangerId;
        AanleveringId = cmd.AanleveringId;
    }


    /// <summary>
    /// Set the status as readed.
    /// </summary>
    /// <param name="cmd">The mark as read command.</param>
    public void MarkAsRead(MarkAanleverberichtAsRead cmd)
    {
        Gelezen = true;
        LaastGelezenOp = DateTime.Now;
        LaatsteLezerId = cmd.LaatsteLezerId;
    }


    /// <summary>
    /// Sets the status to open.
    /// </summary>
    public void Open()
    {
        AanleverberichtStatus = AanleverberichtStatus.Open;
    }

    /// <summary>
    /// Sets the status to closed.
    /// Replying is not possible anymore.
    /// </summary>
    public void Close()
    {
        AanleverberichtStatus = AanleverberichtStatus.Gesloten;
    }
}
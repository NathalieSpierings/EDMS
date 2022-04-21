using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

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
    [Required, MaxLength]
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
    [Required, Column(TypeName = "datetime2")]
    public DateTime GeplaatstOp { get; set; }

    /// <summary>
    /// The last readed date of the aanleverbericht.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? LaastGelezenOp { get; set; }

    /// <summary>
    /// The status of the aanleverbericht.
    /// </summary>
    public AanleverberichtStatus AanleverberichtStatus { get; set; }


    #region Navigation properties
    
    public Guid? LaasteLezerId { get; set; }
    public virtual Medewerker LaasteLezer { get; set; }
    
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

    //public Aanleverbericht(CreateAanleverbericht cmd, int sortOrder)
    //{
    //    Volgorde = sortOrder;
    //    AanleverberichtStatus = AanleverberichtStatus.Open;

    //    AddAndApplyEvent(new AanleverberichtGeplaatst
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        UserDisplayName = cmd.UserDisplayName,

    //        GeplaatstOp = DateTime.Now,
    //        Onderwerp = cmd.Onderwerp,
    //        Bericht = cmd.Bericht,
    //        Afzender = cmd.Afzender,
    //        Ontvanger = cmd.Ontvanger,
    //        Gelezen = "Nee",
    //        ParentId = cmd.ParentId,
    //        AfzenderId = cmd.AfzenderId,
    //        OntvangerId = cmd.OntvangerId,
    //        AanleveringId = cmd.AanleveringId,
    //        AanleverberichtStatus = cmd.AanleverberichtStatus.ToString()
    //    });
    //}

    //public void MarkAsRead(MarkAanleverberichtAsRead cmd)
    //{
    //    Gelezen = true;
    //    LaastGelezenOp = DateTime.Now;
    //    LaasteLezerId = cmd.LaatsteLezerId;
    //}

    //public void Open(OpenAanleverbericht cmd)
    //{
    //    switch (AanleverberichtStatus)
    //    {
    //        case AanleverberichtStatus.Open:
    //            throw new Exception("Aanleverbericht is al geopend.");
    //    }

    //    AddAndApplyEvent(new AanleverberichtGeopend
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        AanleverberichtStatus = AanleverberichtStatus.Open.ToString()
    //    });
    //}

    //public void Close(CloseAanleverbericht cmd)
    //{
    //    switch (AanleverberichtStatus)
    //    {
    //        case AanleverberichtStatus.Gesloten:
    //            throw new Exception("Aanleverbericht is al gesloten.");
    //    }

    //    AddAndApplyEvent(new AanleverberichtGesloten
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        AanleverberichtStatus = AanleverberichtStatus.Gesloten.ToString()
    //    });
    //}

    //#region Private methods

    //private void Apply(AanleverberichtGeplaatst @event)
    //{
    //    Id = @event.AggregateRootId;
    //    GeplaatstOp = @event.GeplaatstOp;
    //    Onderwerp = @event.Onderwerp;
    //    Bericht = @event.Bericht;
    //    Gelezen = false;
    //    ParentId = @event.ParentId;
    //    AfzenderId = @event.AfzenderId;
    //    OntvangerId = @event.OntvangerId;
    //    AanleveringId = @event.AanleveringId;
    //}

    //private void Apply(AanleverberichtGeopend @event)
    //{
    //    AanleverberichtStatus = AanleverberichtStatus.Open;
    //}

    //private void Apply(AanleverberichtGesloten @event)
    //{
    //    AanleverberichtStatus = AanleverberichtStatus.Gesloten;
    //}


    //#endregion
}
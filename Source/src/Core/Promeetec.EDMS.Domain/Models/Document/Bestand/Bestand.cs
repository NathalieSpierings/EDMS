using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand;

public class Bestand : AggregateRoot
{
    /// <summary>
    /// The name of the file.
    /// </summary>
    [Required, MaxLength(450)]
    public string FileName { get; set; }

    /// <summary>
    /// The size of the file.
    /// </summary>
    [Required]
    public int FileSize { get; set; }

    /// <summary>
    /// The extension of the file.
    /// </summary>
    [MaxLength(50)]
    public string Extension { get; set; }

    /// <summary>
    /// The mime type of the file.
    /// </summary>
    [Required, MaxLength(450)]
    public string MimeType { get; set; }

    /// <summary>
    /// The content of the file.
    /// </summary>
    public byte[] Data { get; set; }

    /// <summary>
    /// Date the file has been created.
    /// </summary>
    [Required, Column(TypeName = "datetime2")]
    public DateTime AangemaaktOp { get; set; }

    /// <summary>
    /// Unique identiefier of the creator of the file.
    /// </summary>
    public Guid? AangemaaktDoor { get; set; }

    /// <summary>
    /// Name of the creator of the file.
    /// </summary>
    [MaxLength(450)]
    public string AangemaaktDoorNaam { get; set; }

    /// <summary>
    /// The last edit date of the file.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? AangepastOp { get; set; }

    /// <summary>
    /// Name of the last editor for the file.
    /// </summary>
    public Guid? AangepastDoor { get; set; }


    #region Navigation properties
    
    public Guid EigenaarId { get; set; }
    public virtual Medewerker Eigenaar { get; set; }
    public virtual AanleverbestandSamenvatting Samenvatting { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty file.
    /// </summary>
    public Bestand()
    {

    }

    //public Bestand(NieuwBestand cmd)
    //{
    //    Data = cmd.Data;

    //    AddAndApplyEvent(new BestandAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //  UserDisplayName = cmd.UserDisplayName,

    //        Bestandsnaam = cmd.FileName,
    //        Bestandsgrootte = cmd.FileSize,
    //        Extensie = cmd.Extension,
    //        MimeType = cmd.MimeType,
    //        EigenaarId = cmd.EigenaarId
    //    });
    //}

    //public void Update(WijzigBestand cmd)
    //{
    //    AddAndApplyEvent(new BestandGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //  UserDisplayName = cmd.UserDisplayName,

    //        FileName = cmd.FileName,
    //        EigenaarId = cmd.EigenaarId
    //    });
    //}

    //public void WijzigEigenaar(WijzigEigenaarBestand cmd)
    //{
    //    AddAndApplyEvent(new EigenaarBestandGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        //  UserDisplayName = cmd.UserDisplayName,
    //        UserId = cmd.UserId,
    //        Eigenaar = cmd.Eigenaar,
    //        EigenaarId = cmd.EigenaarId
    //    });
    //}


    //#region Private methods

    //private void Apply(BestandAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    FileName = @event.Bestandsnaam;
    //    FileSize = @event.Bestandsgrootte;
    //    Extension = @event.Extensie;
    //    MimeType = @event.MimeType;
    //    Data = @event.Data;
    //    AangemaaktOp = DateTime.Now;
    //    AangemaaktDoor = @event.UserId;
    //    AangemaaktDoorNaam = @event.UserDisplayName;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //private void Apply(BestandGewijzigd @event)
    //{
    //    FileName = @event.FileName;
    //    EigenaarId = @event.EigenaarId;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //private void Apply(EigenaarBestandGewijzigd @event)
    //{
    //    EigenaarId = @event.EigenaarId;
    //}


    //#endregion
}
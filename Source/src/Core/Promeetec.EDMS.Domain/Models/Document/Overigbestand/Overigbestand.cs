using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand;

public class Overigbestand : Bestand.Bestand
{
    #region Navigation properties

    public Guid AanleveringId { get; set; }
    public virtual Aanlevering Aanlevering { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty overig bestand.
    /// </summary>
    public Overigbestand()
    {

    }

    //public Overigbestand(NieuwOverigbestand cmd)
    //{
    //    Extension = cmd.Extension;
    //    MimeType = cmd.MimeType;
    //    Data = cmd.Data;

    //    AddAndApplyEvent(new OverigbestandAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        AanleveringId = cmd.AanleveringId,
    //        ReferentiePromeetec = cmd.ReferentiePromeetec,
    //        Bestandsnaam = cmd.FileName,
    //        Bestandsgrootte = cmd.FileSize,
    //        EigenaarId = cmd.EigenaarId,
    //        Eigenaar = cmd.Eigenaar
    //    });
    //}



    //#region Private methods

    //private void Apply(OverigbestandAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    AanleveringId = @event.AanleveringId;
    //    FileName = @event.Bestandsnaam;
    //    FileSize = @event.Bestandsgrootte;
    //    EigenaarId = @event.EigenaarId;
    //    AangemaaktDoorNaam = @event.UserDisplayName;
    //    AangemaaktDoor = @event.UserId;
    //    AangemaaktOp = DateTime.Now;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //#endregion
}
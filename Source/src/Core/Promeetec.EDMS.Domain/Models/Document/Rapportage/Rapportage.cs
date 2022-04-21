using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

namespace Promeetec.EDMS.Domain.Models.Document.Rapportage;

public class Rapportage : Bestand.Bestand
{
    /// <summary>
    /// The referentie for the rapportage.
    /// </summary>
    [Required, MaxLength(200)]
    public string Referentie { get; set; }

    /// <summary>
    /// The kind of rapportage.
    /// </summary>
    public RapportageSoort RapportageSoort { get; set; }


    #region Navigation properties

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty rapportage file.
    /// </summary>
    public Rapportage()
    {

    }

    //public Rapportage(NieuweRapportage cmd)
    //{
    //    EigenaarId = cmd.EigenaarId;
    //    Extension = cmd.Extension;
    //    MimeType = cmd.MimeType;
    //    Data = cmd.Data;
    //    OrganisatieId = cmd.OrganisatieId;
    //    RapportageSoort = cmd.RapportageSoort;

    //    AddAndApplyEvent(new RapportageAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        ReferentiePromeetec = cmd.ReferentiePromeetec,
    //        Bestandsnaam = cmd.FileName,
    //        Bestandsgrootte = cmd.FileSize,
    //        Eigenaar = cmd.Eigenaar,
    //        RapportageSoort = cmd.RapportageSoort.ToString()
    //    });
    //}


    //#region Private methods

    //private void Apply(RapportageAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Referentie = @event.ReferentiePromeetec;
    //    FileName = @event.Bestandsnaam;
    //    FileSize = @event.Bestandsgrootte;
    //    AangemaaktDoor = @event.UserId;
    //    AangemaaktOp = DateTime.Now;
    //    AangemaaktDoorNaam = @event.UserDisplayName;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //#endregion
}
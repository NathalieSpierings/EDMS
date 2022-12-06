using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

public class Aanleverbestand : Bestand.Bestand
{
    /// <summary>
    /// The period of the aanleverbestand.
    /// </summary>
    [MaxLength(20)]
    public string Periode { get; set; }

    /// <summary>
    /// Indicator if the aanleverbestand is checked yes or no.
    /// </summary>
    public bool Gecontroleerd { get; set; }
    

    #region Navigation properties

    public Guid? ZorgstraatId { get; set; }
    public virtual Zorgstraat Zorgstraat { get; set; }
    
    public Guid? EiStandaardId { get; set; }
    public virtual EiStandaard EiStandaard { get; set; }
    
    public Guid? AanleveringId { get; set; }
    public virtual Aanlevering Aanlevering { get; set; }


    #endregion

    /// <summary>
    /// Creates an empty aanleverbestand.
    /// </summary>
    public Aanleverbestand()
    {

    }

    //public Aanleverbestand(NieuwAanleverbestand cmd)
    //{
    //    Data = cmd.Data;
    //    WorkFlowState = cmd.WorkFlowState;
    //    Extension = cmd.Extension;
    //    MimeType = cmd.MimeType;
    //    AanleveringId = cmd.AanleveringId;
    //    EigenaarId = cmd.EigenaarId;
    //    VoorraadId = cmd.VoorraadId;
    //    ZorgstraatId = cmd.ZorgstraatId;
    //    EiStandaardId = cmd.EiStandaardId;

    //    AddAndApplyEvent(new AanleverbestandAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Periode = cmd.Periode,
    //        WorkFlowState = cmd.WorkFlowState.ToString(),
    //        Bestandsnaam = cmd.FileName,
    //        Bestandsgrootte = cmd.FileSize,
    //        Zorgstraat = cmd.Zorgstraat,
    //        Eigenaar = cmd.Eigenaar
    //    });
    //}

    //public void Update(WijzigAanleverbestand cmd)
    //{
    //    WorkFlowState = cmd.WorkFlowState;
    //    EigenaarId = cmd.EigenaarId;
    //    VoorraadId = cmd.VoorraadId;
    //    ZorgstraatId = cmd.ZorgstraatId;
    //    AanleveringId = cmd.AanleveringId;
    //    AddAndApplyEvent(new AanleverbestandGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //  UserDisplayName = cmd.UserDisplayName,

    //        Periode = cmd.Periode,
    //        Zorgstraat = cmd.Zorgstraat,
    //        Eigenaar = cmd.Eigenaar
    //    });
    //}


    //public void UpdateWorkflowState(WijzigAanleverbestandWorkflowState cmd)
    //{
    //    WorkFlowState = cmd.WorkFlowState;

    //    AddAndApplyEvent(new AanleverbestandWorkflowStateGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        WorkFlowState = cmd.WorkFlowState.ToString(),
    //        VoorraadId = cmd.VoorraadId,
    //        AanleveringId = cmd.AanleveringId
    //    });
    //}


    //public void CreateSamenvatting(CreateAanleverbestandSamenvatting cmd)
    //{
    //    var samenvatting = new AanleverbestandSamenvatting
    //    {
    //        EiStandaard = cmd.EiStandaard,
    //        AantalVerzekerdeRecords = cmd.AantalVerzekerdeRecords,
    //        AantalPrestatieRecords = cmd.AantalPrestatieRecords,
    //        TotaalDeclaratiebedrag = cmd.TotaalDeclaratiebedrag,
    //        ZorgverlenersCode = cmd.Zorgverlenerscode,
    //        Praktijkcode = cmd.Praktijkcode,
    //        Instellingscode = cmd.Instellingscode,
    //        Processed = cmd.Processed,
    //        OvergeslagenRows = cmd.OvergeslagenRows,
    //    };
    //    Samenvatting = samenvatting;
    //}

    //public void Controleer(ControleerAanleverbestand cmd)
    //{
    //    AddAndApplyEvent(new AanleverbestandGecontroleerd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,
    //        Gecontroleerd = "Ja"
    //    });
    //}

    //public void OnControleer(OnControleerAanleverbestand cmd)
    //{
    //    AddAndApplyEvent(new AanleverbestandOngecontroleerd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        Gecontroleerd = "Nee"
    //    });
    //}

    //#region Private methods

    //private void Apply(AanleverbestandAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Periode = @event.Periode;
    //    FileName = @event.Bestandsnaam;
    //    FileSize = @event.Bestandsgrootte;
    //    AangemaaktDoor = @event.UserId;
    //    AangemaaktOp = DateTime.Now;
    //    AangemaaktDoorNaam = @event.UserDisplayName;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //private void Apply(AanleverbestandGewijzigd @event)
    //{
    //    Periode = @event.Periode;
    //    AangepastDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //}

    //private void Apply(AanleverbestandWorkflowStateGewijzigd @event)
    //{
    //    VoorraadId = @event.VoorraadId;
    //    AanleveringId = @event.AanleveringId;
    //}


    //private void Apply(AanleverbestandGecontroleerd @event)
    //{
    //    Gecontroleerd = true;
    //}

    //private void Apply(AanleverbestandOngecontroleerd @event)
    //{
    //    Gecontroleerd = false;
    //}

    //#endregion
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;

public class VerbruiksmiddelPrestatie : AggregateRoot
{
    /// <summary>
    /// The vektis agbcode onderneming.
    /// </summary>
    [Required, MaxLength(8)]
    public string AgbCodeOnderneming { get; set; }

    /// <summary>
    /// The hulpmiddelen soort.
    /// </summary>
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }

    /// <summary>
    /// The status of the prestatie.
    /// </summary>
    public VerbruiksmiddelPrestatieStatus Status { get; set; }

    /// <summary>
    /// The profiel code.
    /// </summary>
    public ProfielCode? ProfielCode { get; set; }

    /// <summary>
    /// The start date of the profiel.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ProfielStartdatum { get; set; }

    /// <summary>
    /// The end date of the profiel.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ProfielEinddatum { get; set; }

    /// <summary>
    /// The Z-Index number.
    /// </summary>
    public int? ZIndex { get; set; }

    /// <summary>
    /// The prestatie date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? PrestatieDatum { get; set; }

    /// <summary>
    /// The amount.
    /// </summary>
    public int? Hoeveelheid { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// The unique identifier of the creator.
    /// </summary>
    [Required]
    public Guid AangemaaktDoorId { get; set; }

    /// <summary>
    /// The creation by name.
    /// </summary>
    public string AangemaaktDoor { get; set; }


    #region Navigation properties
    
    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
    
    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty verbruiksmiddel prestatie.
    /// </summary>
    public VerbruiksmiddelPrestatie()
    {

    }

    //public VerbruiksmiddelPrestatie(NieuweVerbruiksmiddelPrestatie cmd)
    //{
    //    TimeStamp = DateTime.Now;
    //    AangemaaktDoorId = cmd.UserId;
    //    AangemaaktDoor = cmd.UserDisplayName;

    //    AddAndApplyEvent(new VerbruiksmiddelPrestatieAangemaakt
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        AgbCodeOnderneming = cmd.AgbCodeOnderneming,
    //        HulpmiddelenSoort = cmd.HulpmiddelenSoort,
    //        Status = cmd.Status,
    //        VerwerkJaar = cmd.VerwerkJaar,
    //        VerwerkMaand = cmd.VerwerkMaand,
    //        ProfielCode = cmd.ProfielCode,
    //        ProfielStartdatum = cmd.ProfielStartdatum,
    //        ProfielEinddatum = cmd.ProfielEinddatum,
    //        ZIndex = cmd.ZIndex,
    //        PrestatieDatum = cmd.PrestatieDatum,
    //        Hoeveelheid = cmd.Hoeveelheid,
    //        EigenaarId = cmd.EigenaarId,
    //        VerzekerdeId = cmd.VerzekerdeId,
    //        OrganisatieId = cmd.OrganisatieId
    //    });
    //}

    //public void Update(WijzigVerbruiksmiddelPrestatie cmd)
    //{
    //    AgbCodeOnderneming = cmd.AgbCodeOnderneming;
    //    ZIndex = cmd.ZIndex;
    //    PrestatieDatum = cmd.PrestatieDatum;
    //    Hoeveelheid = cmd.Hoeveelheid;
    //    VerzekerdeId = cmd.VerzekerdeId;
    //}


    //public void Process(VerwerkVerbruiksmiddelPrestatie cmd)
    //{
    //    if (Status == VerbruiksmiddelPrestatieStatus.Verwerkt)
    //        throw new Exception("Deze verbruiksmiddel prestatie is al verwerkt");

    //    AddAndApplyEvent(new VerbruiksmiddelPrestatieVerwerkt
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,
    //    });
    //}


    //#region Private methods

    //private void Apply(VerbruiksmiddelPrestatieAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    AgbCodeOnderneming = @event.AgbCodeOnderneming;
    //    HulpmiddelenSoort = @event.HulpmiddelenSoort;
    //    Status = @event.Status;
    //    ProfielCode = @event.ProfielCode;
    //    ProfielStartdatum = @event.ProfielStartdatum;
    //    ProfielEinddatum = @event.ProfielEinddatum;
    //    ZIndex = @event.ZIndex;
    //    PrestatieDatum = @event.PrestatieDatum;
    //    Hoeveelheid = @event.Hoeveelheid;
    //    VerzekerdeId = @event.VerzekerdeId;
    //    OrganisatieId = @event.OrganisatieId;
    //}

    //private void Apply(VerbruiksmiddelPrestatieVerwerkt @event)
    //{
    //    Status = VerbruiksmiddelPrestatieStatus.Verwerkt;
    //}

    //#endregion
}

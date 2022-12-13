using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

public class Aanlevering : AggregateRoot
{
    /// <summary>
    /// The year for the aanlevering.
    /// </summary>
    [Required]
    public int Jaar { get; set; }

    /// <summary>
    /// The referentie for the aanlevering.
    /// </summary>
    [Required, MaxLength(200)]
    public string Referentie { get; set; }

    /// <summary>
    /// The referentie Promeetec for the aanlevering.
    /// </summary>
    [Required, MaxLength(200)]
    public string ReferentiePromeetec { get; set; }

    /// <summary>
    /// The remarks for the aanlevering.
    /// </summary>
    [MaxLength(1024)]
    public string Opmerking { get; set; }

    /// <summary>
    /// Indicator if the user is allowed to add documents to the aanlevering.
    /// </summary>
    public bool ToevoegenBestand { get; set; }

    /// <summary>
    /// The aanleverstatus of the aanlevering.
    /// </summary>
    public AanleverStatus AanleverStatus { get; set; }

    /// <summary>
    /// The status of the aanlevering.
    /// </summary>
    [Required]
    public Status Status { get; set; }

    /// <summary>
    /// The aanlever date of the aanlevering.
    /// </summary>
    [Required, Column(TypeName = "datetime2")]
    public DateTime Aanleverdatum { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// The unique identifier of the creator of the aanlevering.
    /// </summary>
    public Guid? AangemaaktDoor { get; set; }

    /// <summary>
    /// The last update date of the aanlevering.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? AangepastOp { get; set; }

    /// <summary>
    /// The unique identifier of the last updater of the aanlevering.
    /// </summary>
    public Guid? AangepastDoor { get; set; }


    #region Navigation properties

    public Guid EigenaarId { get; set; }
    public virtual Medewerker Eigenaar { get; set; }
    
    public Guid? BehandelaarId { get; set; }
    public virtual Medewerker Behandelaar { get; set; }
    
    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }

    public virtual ICollection<Aanleverbericht.Aanleverbericht> Aanleverberichten { get; set; }
    public virtual ICollection<Aanleverbestand> Aanleverbestanden { get; set; }
    public virtual ICollection<Document.Overigbestand.Overigbestand> Overigebestanden { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty aanlevering.
    /// </summary>
    public Aanlevering()
    {

    }

    //public Aanlevering(CreateAanlevering cmd)
    //{
    //    ToevoegenBestand = cmd.ToevoegenBestand;
    //    OrganisatieId = cmd.OrganisatieId;
    //    BehandelaarId = cmd.BehandelaarId;
    //    EigenaarId = cmd.EigenaarId;

    //    AddAndApplyEvent(new AanleveringAangemaakt
    //    {
    //        Source = cmd.Source,
    //        AggregateRootId = cmd.AggregateRootId,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        UserId = cmd.UserId,

    //        Organisatie = cmd.Organisatie,
    //        Behandelaar = cmd.Behandelaar,
    //        Eigenaar = cmd.Eigenaar,
    //        Status = Status.Actief.ToString(),
    //        Jaar = DateTime.Now.Year,
    //        Aanleverdatum = DateTime.Now,
    //        Referentie = cmd.Referentie,
    //        ReferentiePromeetec = cmd.ReferentiePromeetec,
    //        AanleverStatus = AanleverStatus.Aangemaakt.ToString(),
    //        ToevoegenBestand = cmd.ToevoegenBestand ? "Ja" : "Nee",
    //        Opmerking = cmd.Opmerking
    //    });
    //}

    //public void Update(UpdateAanlevering cmd)
    //{
    //    AanleverStatus = cmd.AanleverStatus;
    //    ToevoegenBestand = cmd.ToevoegenBestand;
    //    BehandelaarId = cmd.BehandelaarId;
    //    EigenaarId = cmd.EigenaarId;

    //    AddAndApplyEvent(new AanleveringGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        ReferentiePromeetec = cmd.ReferentiePromeetec,
    //        AanleverStatus = cmd.AanleverStatus.ToString(),
    //        ToevoegenBestand = cmd.ToevoegenBestand ? "Ja" : "Nee",
    //        Behandelaar = cmd.Behandelaar,
    //        Eigenaar = cmd.Eigenaar,
    //        Opmerking = cmd.Opmerking
    //    });
    //}


    //public void WijzigEigenaar(ChangeEigenaarAanlevering cmd)
    //{
    //    AddAndApplyEvent(new EigenaarAanleveringGewijzigd
    //    {
    //        AggregateRootId = Id,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        UserId = cmd.UserId,
    //        Eigenaar = cmd.Eigenaar,
    //        EigenaarId = cmd.EigenaarId
    //    });
    //}

    //public void Delete(DeleteAanlevering cmd)
    //{
    //    AddAndApplyEvent(new AanleveringVerwijderd
    //    {
    //        AggregateRootId = Id,
    //        //UserDisplayName = cmd.UserDisplayName,
    //        UserId = cmd.UserId,

    //        Status = Status.Verwijderd.ToString()
    //    });
    //}

    //public int BerichtSortOrder(CreateAanleverbericht cmd)
    //{
    //    if (Aanleverberichten.FirstOrDefault(x => x.Id == cmd.Id) != null)
    //        return 0;

    //    int sortOrder;
    //    if (cmd.ParentId == null || cmd.ParentId == Guid.Empty)
    //    {
    //        sortOrder = Aanleverberichten.Count(x => x.ParentId == Guid.Empty || x.ParentId == null) + 1;
    //    }
    //    else
    //    {
    //        sortOrder = Aanleverberichten.Count(x => x.ParentId == cmd.ParentId) + 1;
    //    }

    //    return sortOrder;
    //}


    //#region Private methods

    //private void Apply(AanleveringAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;

    //    Status = Status.Actief;
    //    AanleverStatus = AanleverStatus.Aangemaakt;
    //    Jaar = DateTime.Now.Year;
    //    Aanleverdatum = DateTime.Now;
    //    Referentie = @event.Referentie;
    //    ReferentiePromeetec = @event.ReferentiePromeetec;
    //    Opmerking = @event.Opmerking;
    //    AangemaaktDoor = @event.UserId;
    //    AangepastOp = DateTime.Now;
    //    AangepastDoor = @event.UserId;
    //}

    //private void Apply(AanleveringGewijzigd @event)
    //{
    //    ReferentiePromeetec = @event.ReferentiePromeetec;
    //    Opmerking = @event.Opmerking;
    //    AangepastOp = DateTime.Now;
    //    AangepastDoor = @event.UserId;
    //}

    //private void Apply(EigenaarAanleveringGewijzigd @event)
    //{
    //    EigenaarId = @event.EigenaarId;
    //}

    //private void Apply(AanleveringVerwijderd @event)
    //{
    //    Status = Shared.Status.Verwijderd;
    //    AangepastOp = DateTime.Now;
    //    AangepastDoor = @event.UserId;
    //}

    //#endregion
}
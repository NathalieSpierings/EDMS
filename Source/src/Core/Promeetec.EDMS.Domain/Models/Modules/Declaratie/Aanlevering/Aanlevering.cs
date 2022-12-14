using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
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


    /// <summary>
    /// Creates an aanlevering.
    /// </summary>
    /// <param name="cmd">The create aanlevering command.</param>
    public Aanlevering(CreateAanlevering cmd)
    {
        Id = cmd.Id;

        Referentie = cmd.Referentie;
        ReferentiePromeetec = cmd.ReferentiePromeetec;
        Opmerking = cmd.Opmerking;
        ToevoegenBestand = cmd.ToevoegenBestand;
        OrganisatieId = cmd.OrganisatieId;
        BehandelaarId = cmd.BehandelaarId;
        EigenaarId = cmd.EigenaarId;
        Status = Status.Actief;
        AanleverStatus = AanleverStatus.Aangemaakt;
        Jaar = DateTime.Now.Year;
        Aanleverdatum = DateTime.Now;
        TimeStamp = DateTime.Now;
        AangemaaktDoor = cmd.UserId;
    }


    /// <summary>
    /// Update the details of the aanlevering.
    /// </summary>
    /// <param name="cmd">The update aanlevering command.</param>
    public void Update(UpdateAanlevering cmd)
    {
        ReferentiePromeetec = cmd.ReferentiePromeetec;
        Opmerking = cmd.Opmerking;
        AanleverStatus = cmd.AanleverStatus;
        ToevoegenBestand = cmd.ToevoegenBestand;
        BehandelaarId = cmd.BehandelaarId;
        EigenaarId = cmd.EigenaarId;
        AangepastOp = DateTime.Now;
        AangepastDoor = cmd.UserId;
    }


    /// <summary>
    /// Set the status as deleted.
    /// </summary>
    /// <param name="cmd">The delete aanlevering command.</param>
    public void Delete(DeleteAanlevering cmd)
    {
        Status = Status.Verwijderd;
        AangepastOp = DateTime.Now;
        AangepastDoor = cmd.UserId;
    }


    /// <summary>
    /// Update the owner of the aanlevering.
    /// </summary>
    /// <param name="cmd">The change owner command.</param>
    public void WijzigEigenaar(ChangeEigenaarAanlevering cmd)
    {
        EigenaarId = cmd.EigenaarId;
    }

    /// <summary>
    /// Sorts the aanleverberichten.
    /// </summary>
    /// <param name="cmd">The create aanleverbericht command.</param>
    public int BerichtSortOrder(CreateAanleverbericht cmd)
    {
        if (Aanleverberichten.FirstOrDefault(x => x.Id == cmd.Id) != null)
            return 0;

        int sortOrder;
        if (cmd.ParentId == null || cmd.ParentId == Guid.Empty)
        {
            sortOrder = Aanleverberichten.Count(x => x.ParentId == Guid.Empty || x.ParentId == null) + 1;
        }
        else
        {
            sortOrder = Aanleverberichten.Count(x => x.ParentId == cmd.ParentId) + 1;
        }

        return sortOrder;
    }

}
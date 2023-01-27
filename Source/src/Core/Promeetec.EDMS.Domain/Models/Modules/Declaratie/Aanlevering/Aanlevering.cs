using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;

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
    public string? Opmerking { get; set; }

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
    [Required]
    public DateTime Aanleverdatum { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime AangemaaktOp { get; set; }

    /// <summary>
    /// Unique identiefier of the creator of the file.
    /// </summary>
    public Guid AangemaaktDoorId { get; set; }

    /// <summary>
    /// Name of the creator of the file.
    /// </summary>
    [MaxLength(450)]
    public string? AangemaaktDoor { get; set; }


    /// <summary>
    /// The last edit date of the file.
    /// </summary>
    public DateTime? AangepastOp { get; set; }

    /// <summary>
    /// Name of the last editor for the file.
    /// </summary>
    public Guid? AangepastDoorId { get; set; }

    /// <summary>
    /// Name of the last editor of the file.
    /// </summary>
    [MaxLength(450)]
    public string? AangepastDoor { get; set; }


    /// <summary>
    /// The date the Status has been set to Verwijderd.
    /// </summary>
    public DateTime? VerwijderdOp { get; set; }

    /// <summary>
    /// The unique identifier of the deleter.
    /// </summary>
    public Guid? VerwijderdDoorId { get; set; }

    /// <summary>
    /// The name of the deleter.
    /// </summary>
    public string? VerwijderdDoor { get; set; }

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
        AangemaaktOp = DateTime.Now;
        AangemaaktDoorId = cmd.UserId;
        AangemaaktDoor = cmd.UserDisplayName;
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
        AangepastDoorId = cmd.UserId;
        AangepastDoor = cmd.UserDisplayName;
    }


    /// <summary>
    /// Set the status as deleted.
    /// </summary>
    /// <param name="cmd">The delete aanlevering command.</param>
    public void Delete(DeleteAanlevering cmd)
    {
        Status = Status.Verwijderd;
        AangepastOp = DateTime.Now;
        AangepastDoorId = cmd.UserId;
        AangepastDoor = cmd.UserDisplayName;

        VerwijderdOp = DateTime.Now;
        VerwijderdDoorId = cmd.UserId;
        VerwijderdDoor = cmd.UserDisplayName;
    }


    /// <summary>
    /// Update the owner of the aanlevering.
    /// </summary>
    /// <param name="cmd">The change owner command.</param>
    public void WijzigEigenaar(ChangeEigenaarAanlevering cmd)
    {
        EigenaarId = cmd.EigenaarId;
        AangepastOp = DateTime.Now;
        AangepastDoorId = cmd.UserId;
        AangepastDoor = cmd.UserDisplayName;
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
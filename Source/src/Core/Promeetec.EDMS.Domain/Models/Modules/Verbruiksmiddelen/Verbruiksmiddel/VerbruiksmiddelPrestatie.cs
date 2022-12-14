using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
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
    public DateTime? ProfielStartdatum { get; set; }

    /// <summary>
    /// The end date of the profiel.
    /// </summary>
    public DateTime? ProfielEinddatum { get; set; }

    /// <summary>
    /// The Z-Index number.
    /// </summary>
    public int? ZIndex { get; set; }

    /// <summary>
    /// The prestatie date.
    /// </summary>
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

    /// <summary>
    /// Creates a verbruiksmiddel prestatie.
    /// </summary>
    /// <param name="cmd">The create verbruiksmiddel prestatie command.</param>
    public VerbruiksmiddelPrestatie(CreateVerbruiksmiddelPrestatie cmd)
    {
        Id = cmd.Id;

        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        HulpmiddelenSoort = cmd.HulpmiddelenSoort;
        Status = cmd.Status;
        ProfielCode = cmd.ProfielCode;
        ProfielStartdatum = cmd.ProfielStartdatum;
        ProfielEinddatum = cmd.ProfielEinddatum;
        ZIndex = cmd.ZIndex;
        PrestatieDatum = cmd.PrestatieDatum;
        Hoeveelheid = cmd.Hoeveelheid;
        VerzekerdeId = cmd.VerzekerdeId;
        OrganisatieId = cmd.OrganisatieId;
        TimeStamp = DateTime.Now;
        AangemaaktDoorId = cmd.UserId;
        AangemaaktDoor = cmd.UserDisplayName;
    }

    /// <summary>
    /// Update the details of the verbruiksmiddel prestatie.
    /// </summary>
    /// <param name="cmd">The update verbruiksmiddel prestatie command.</param>
    public void Update(UpdateVerbruiksmiddelPrestatie cmd)
    {
        AgbCodeOnderneming = cmd.AgbCodeOnderneming;
        ZIndex = cmd.ZIndex;
        PrestatieDatum = cmd.PrestatieDatum;
        Hoeveelheid = cmd.Hoeveelheid;
        VerzekerdeId = cmd.VerzekerdeId;
    }

    /// <summary>
    /// Sets the status of the verbruiksmiddel prestatie as verwerkt.
    /// </summary>
    public void Process()
    {
        Status = VerbruiksmiddelPrestatieStatus.Verwerkt;
    }
}

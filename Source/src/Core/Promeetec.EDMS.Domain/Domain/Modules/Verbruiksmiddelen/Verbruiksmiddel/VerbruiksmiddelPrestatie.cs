using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel;

public class VerbruiksmiddelPrestatie : AggregateRoot
{

    /// <summary>
    /// The vektis agbcode onderneming.
    /// </summary>
    [Required, StringLength(8)]
    public string AgbCodeOnderneming { get; set; }

    /// <summary>
    /// The hulpmiddelen soort.
    /// </summary>
    [Required]
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }


    /// <summary>
    /// The status of the prestatie.
    /// </summary>
    [Required]
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
    /// The Z-Index.
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
    public Guid AangemaaktDoorId { get; set; }

    /// <summary>
    /// The creation by name.
    /// </summary>
    public string AangemaaktDoor { get; set; }


    #region Navigation properties


    /// <summary>
    /// The unique identifier of the insured person for the verbruiksmiddel prestatie.
    /// </summary>
    public Guid VerzekerdeId { get; set; }

    /// <summary>
    /// Reference to the insured person for the verbruiksmiddel prestatie.
    /// </summary>
    public Verzekerde Verzekerde { get; set; }


    /// <summary>
    /// The unique identifier of the organisatie for the verbruiksmiddel prestatie.
    /// </summary>
    public Guid OrganisatieId { get; set; }


    /// <summary>
    /// Reference to the organisatie for the verbruiksmiddel prestatie.
    /// </summary>
    public Organisatie Organisatie { get; set; }

    #endregion

}

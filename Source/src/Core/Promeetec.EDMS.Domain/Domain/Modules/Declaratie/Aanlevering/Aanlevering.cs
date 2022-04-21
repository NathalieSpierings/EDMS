using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Domain.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanlevering;

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
    [Required, StringLength(200)]
    public string Referentie { get; set; }

    /// <summary>
    /// The referentie Promeetec for the aanlevering.
    /// </summary>
    [Required, StringLength(200)]
    public string ReferentiePromeetec { get; set; }

    /// <summary>
    /// The remarks for the aanlevering.
    /// </summary>
    [MaxLength]
    public string Opmerking { get; set; }

    /// <summary>
    /// Indicator if the user is allowed to add documents to the aanlevering.
    /// </summary>
    public bool ToevoegenBestand { get; set; }

    /// <summary>
    /// The aanleverstatus of the aanlevering.
    /// </summary>
    [Required]
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

    /// <summary>
    /// The unique identifier of the eigenaar of the aanlevering.
    /// </summary>
    public Guid EigenaarId { get; set; }

    /// <summary>
    /// Reference to the eigenaar for the aanlevering.
    /// </summary>
    public Medewerker Eigenaar { get; set; }

    /// <summary>
    /// The unique identifier of the behandelaar of the aanlevering.
    /// </summary>
    public Guid? BehandelaarId { get; set; }


    /// <summary>
    /// Reference to the behandelaar for the aanlevering.
    /// </summary>
    public Medewerker Behandelaar { get; set; }

    /// <summary>
    /// The unique identifier of the organisatie of the aanlevering.
    /// </summary>
    public Guid OrganisatieId { get; set; }

    /// <summary>
    /// Reference to the organisatie for the aanlevering.
    /// </summary>
    public Organisatie Organisatie { get; set; }

    public IList<Aanleverbericht.Aanleverbericht> Aanleverberichten { get; set; } = new List<Aanleverbericht.Aanleverbericht>();
    public IList<Aanleverbestand> Aanleverbestanden { get; set; } = new List<Aanleverbestand>();
    public IList<Document.Overigbestand.Overigbestand> Overigebestanden { get; set; } = new List<Document.Overigbestand.Overigbestand>();

    #endregion


    public Aanlevering() { }
}
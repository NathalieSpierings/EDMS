using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Domain.Modules.GLI.Behandelplan;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.GLI.Intake;

public class GliIntake : AggregateRoot
{
    /// <summary>
    /// The date of the intake.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime IntakeDatum { get; set; }

    /// <summary>
    /// The remarks for the intake.
    /// </summary>
    [MaxLength]
    public string Opmerking { get; set; }

    /// <summary>
    /// Indicator if the intake is verwerkt yes or no.
    /// </summary>
    public bool Verwerkt { get; set; }

    /// <summary>
    /// The verwerkt op date.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? VerwerktOp { get; set; }

    /// <summary>
    /// The status of the intake.
    /// </summary>
    public GliStatus GliStatus { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the behandelaar for the intake.
    /// </summary>
    public Guid BehandelaarId { get; set; }

    /// <summary>
    /// Reference to the behandelaar for the intake.
    /// </summary>
    public Medewerker Behandelaar { get; set; }

    /// <summary>
    /// The unique identifier of the verzekerde for the intake.
    /// </summary>
    public Guid VerzekerdeId { get; set; }

    /// <summary>
    /// Reference to the verzekerde for the intake.
    /// </summary>
    public Verzekerde Verzekerde { get; set; }

    /// <summary>
    /// The unique identifier of the organisatie for the intake.
    /// </summary>
    public Guid OrganisatieId { get; set; }

    /// <summary>
    /// Reference to the organisatie for the intake.
    /// </summary>
    public Organisatie Organisatie { get; set; }

    public IList<GliBehandelplan> Behandelplannen { get; set; } = new List<GliBehandelplan>();


    #endregion
}

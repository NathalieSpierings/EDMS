using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Domain.Modules.GLI.Intake;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.GLI.Behandelplan;

public class GliBehandelplan : AggregateRoot
{
    /// <summary>
    /// The start date of the behandelfase.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime Startdatum { get; set; }


    [Column(TypeName = "datetime2")]
    public DateTime Einddatum { get; set; }

    public GliProgramma GliProgramma { get; set; }
    public GliBehandelfase Fase { get; set; }


    [MaxLength]
    public string Opmerking { get; set; }

    public bool VoortijdigGestopt { get; set; }


    [Column(TypeName = "datetime2")]
    public DateTime? VoortijdigeStopdatum { get; set; }


    public bool Verwerkt { get; set; }


    [Column(TypeName = "datetime2")]
    public DateTime? VerwerktOp { get; set; }

    public GliStatus GliStatus { get; set; }


    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


    #region Navigation properties

    public Guid? RedenEindeZorgId { get; set; }
    public RedenEindeZorg RedenEindeZorg { get; set; }

    public Guid BehandelaarId { get; set; }
    public Medewerker Behandelaar { get; set; }

    public Guid VerzekerdeId { get; set; }
    public Verzekerde Verzekerde { get; set; }

    public Guid IntakeId { get; set; }
    public GliIntake Intake { get; set; }

    #endregion


    public GliBehandelplan() { }


}

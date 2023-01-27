using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;

public class GliIntake : AggregateRoot
{
    /// <summary>
    /// The date of the intake.
    /// </summary>
    [Required]
    public DateTime IntakeDatum { get; set; }


    /// <summary>
    /// The remarks for the intake.
    /// </summary>
    [MaxLength(1024)]
    public string? Opmerking { get; set; }


    /// <summary>
    /// Indicator if the intake is verwerkt.
    /// </summary>
    public bool Verwerkt { get; set; }

    /// <summary>
    /// The verwerkt date.
    /// </summary>
    public DateTime? VerwerktOp { get; set; }

    /// <summary>
    /// The status of the intake.
    /// </summary>
    public Behandelplan.GliStatus GliStatus { get; set; }

    #region Navigation properties

    public Guid BehandelaarId { get; set; }
    public virtual Medewerker Behandelaar { get; set; }


    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }


    public IList<GliBehandelplan> Behandelplannen { get; set; } = new List<GliBehandelplan>();


    #endregion


    /// <summary>
    /// Creates an empty intake.
    /// </summary>
    public GliIntake() { }

    /// <summary>
    /// Creates an GLI intake.
    /// </summary>
    /// <param name="cmd">The create intake command.</param>
    public GliIntake(CreateIntake cmd)
    {
        Id = cmd.Id;

        IntakeDatum = cmd.IntakeDatum;
        VerzekerdeId = cmd.VerzekerdeId;
        BehandelaarId = cmd.BehandelaarId;
        OrganisatieId = cmd.OrganisatieId;
        GliStatus = Behandelplan.GliStatus.NogNietGestart;
        Opmerking = cmd.Opmerking;
    }

    /// <summary>
    /// Update the details of the GLI intake.
    /// </summary>
    /// <param name="cmd">The update intake command.</param>
    public void UpdateIntake(UpdateIntake cmd)
    {
        IntakeDatum = cmd.IntakeDatum;
        BehandelaarId = cmd.BehandelaarId;
        Opmerking = cmd.Opmerking;
    }

    /// <summary>
    /// Sets the status of the GLI intake as verwerkt.
    /// <param name="cmd">The process intake command.</param>
    /// </summary>
    public void Process(ProcessIntake cmd)
    {
        VerwerktOp = cmd.VerwerktOp;
        Verwerkt = true;
    }

    /// <summary>
    /// Update the status of the GLI intake.
    /// </summary>
    /// <param name="cmd">The update intake status command.</param>
    public void UpdateIntakeStatus(UpdateIntakeStatus cmd)
    {
        GliStatus = cmd.GliStatus;
    }
}
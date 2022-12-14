using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;

public class GliBehandelplan : AggregateRoot
{
    public DateTime Startdatum { get; set; }
    public DateTime Einddatum { get; set; }
    public GliProgramma GliProgramma { get; set; }
    public GliBehandelfase Fase { get; set; }

    [MaxLength(1024)]
    public string Opmerking { get; set; }
    public bool VoortijdigGestopt { get; set; }
    public DateTime? VoortijdigeStopdatum { get; set; }
    public bool Verwerkt { get; set; }
    public DateTime? VerwerktOp { get; set; }
    public GliStatus GliStatus { get; set; }

    #region Navigation properties

    public Guid? RedenEindeZorgId { get; set; }
    public RedenEindeZorg RedenEindeZorg { get; set; }


    public Guid BehandelaarId { get; set; }
    public virtual Medewerker Behandelaar { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }

    public Guid IntakeId { get; set; }
    public virtual GliIntake Intake { get; set; }

    #endregion

    /// <summary>
    /// Creates an empty GLI behandelplan.
    /// </summary>
    public GliBehandelplan() { }


    /// <summary>
    /// Creates and starts an behandeltraject.
    /// </summary>
    /// <param name="cmd">The start behandeltraject command.</param>
    public GliBehandelplan(StartBehandeltraject cmd)
    {
        Id = cmd.Id;

        IntakeId = cmd.IntakeId;
        OrganisatieId = cmd.OrganisatieId;
        VerzekerdeId = cmd.VerzekerdeId;
        BehandelaarId = cmd.BehandelaarId;
        Startdatum = cmd.Startdatum;
        Einddatum = cmd.Einddatum;
        GliProgramma = cmd.Programma;
        Fase = cmd.Fase;
        GliStatus = cmd.GliStatus;
        Opmerking = cmd.Opmerking;
    }

    /// <summary>
    /// Stops the behandeltraject.
    /// </summary>
    /// <param name="cmd">The stop behandeltraject command.</param>
    public void StopBehandeltraject(StopBehandeltraject cmd)
    {
        VoortijdigGestopt = true;
        VoortijdigeStopdatum = cmd.VoortijdigeStopdatum;
        RedenEindeZorgId = cmd.RedenEindeZorgId;
        GliStatus = GliStatus.Gestopt;
        Opmerking = cmd.Opmerking;
    }

    /// <summary>
    /// Stops an behandelplan.
    /// </summary>
    /// <param name="cmd">The stop behandelplan command.</param>
    public void Stopbehandelplan(StopBehandelplan cmd)
    {
        GliStatus = GliStatus.Gestopt;
        VoortijdigGestopt = true;
        VoortijdigeStopdatum = cmd.VoortijdigeStopdatum;
        RedenEindeZorgId = cmd.RedenEindeZorgId;
    }

    /// <summary>
    /// Deletes the behandeltraject.
    /// </summary>
    public void DeleteBehandeltraject()
    {
        GliStatus = GliStatus.Verwijderd;
    }


    /// <summary>
    /// Processes an behandelplan.
    /// </summary>
    /// <param name="cmd">The process behandelplan command.</param>
    public void Process(ProcessBehandelplan cmd)
    {
        VerwerktOp = cmd.VerwerktOp;
        GliStatus = cmd.Status;
        Verwerkt = true;
        //AddAndApplyEvent(new BehandelplanVerwerkt
        //{
        //    AggregateRootId = cmd.AggregateRootId,
        //    UserId = cmd.UserId,
        //    UserDisplayName = cmd.UserDisplayName,

        //    Verwerkt = "Ja",
        //    VerwerktOp = cmd.VerwerktOp.ToString("dd-MM-yyyy"),
        //    Status = cmd.Status.ToString()
        //});
    }

    /// <summary>
    /// Sets the status of the behandelplan.
    /// </summary>
    /// <param name="cmd">The update behandelplan status command.</param>
    public void UpdateStatus(UpdateBehandelplanStatus cmd)
    {
        GliStatus = cmd.Status;
    }
}
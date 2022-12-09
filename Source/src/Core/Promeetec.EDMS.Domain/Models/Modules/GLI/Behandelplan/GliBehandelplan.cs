using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan;

public class GliBehandelplan : AggregateRoot
{
    /// <summary>
    /// The start date of the behandelplan.
    /// </summary>
    [Required]
    public DateTime Startdatum { get; set; }

    /// <summary>
    /// The end date of the behandelplan.
    /// </summary>
    [Required]
    public DateTime Einddatum { get; set; }

    /// <summary>
    /// The GLI programma of the behandelplan.
    /// </summary>
    public GliProgramma GliProgramma { get; set; }

    /// <summary>
    /// The behandelfase of the behandelplan.
    /// </summary>
    public GliBehandelfase Fase { get; set; }

    /// <summary>
    /// The GLI status of the behandelplan.
    /// </summary>
    public GliStatus GliStatus { get; set; }

    /// <summary>
    /// The remarks of the behandelplan.
    /// </summary>
    [MaxLength]
    public string Opmerking { get; set; }

    /// <summary>
    /// Indicator if the behandelplan is stopped premature.
    /// </summary>
    public bool VoortijdigGestopt { get; set; }

    /// <summary>
    /// The premature stop date of the behandelplan.
    /// </summary>
    public DateTime? VoortijdigeStopdatum { get; set; }

    /// <summary>
    /// Indicator if the behandelplan is verwerkt.
    /// </summary>
    public bool Verwerkt { get; set; }

    /// <summary>
    /// The verwerkt op date of the behandelplan.
    /// </summary>
    public DateTime? VerwerktOp { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }


    #region Navigation properties
    
    public Guid? RedenEindeZorgId { get; set; }
    public virtual RedenEindeZorg RedenEindeZorg { get; set; }

    public Guid IntakeId { get; set; }
    public virtual GliIntake Intake { get; set; }

    #endregion

    /// <summary>
    /// Creates an empty GLI behandelplan
    /// </summary>
    public GliBehandelplan()
    {

    }


    //public GliBehandelplan(StartBehandeltraject cmd)
    //{
    //    IntakeId = cmd.IntakeId;
    //    OrganisatieId = cmd.OrganisatieId;
    //    VerzekerdeId = cmd.VerzekerdeId;
    //    BehandelaarId = cmd.BehandelaarId;
    //    Startdatum = cmd.Startdatum;
    //    Einddatum = cmd.Einddatum;
    //    GliProgramma = cmd.Programma;
    //    Fase = cmd.Fase;
    //    GliStatus = cmd.GliStatus;

    //    AddAndApplyEvent(new BehandeltrajectGestart
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Startdatum = cmd.Startdatum.ToString("dd-MM-yyyy"),
    //        Einddatum = cmd.Einddatum.ToString("dd-MM-yyyy"),
    //        GliProgramma = cmd.Programma.ToString(),
    //        Fase = cmd.Fase.ToString(),
    //        Opmerking = cmd.Opmerking
    //    });
    //}

    //public void StopBehandeltraject(StopBehandeltraject cmd)
    //{
    //    RedenEindeZorgId = cmd.RedenEindeZorgId;
    //    VoortijdigeStopdatum = cmd.VoortijdigeStopdatum;
    //    GliStatus = GliStatus.Gestopt;

    //    AddAndApplyEvent(new BehandeltrajectGestopt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        VoortijdigGestopt = "Ja",
    //        VoortijdigeStopdatum = cmd.VoortijdigeStopdatum.ToString("dd-MM-yyyy"),
    //        VoortijdigeStopCode = cmd.VoortijdigeStopCode,
    //        VoortijdigeStopReden = cmd.VoortijdigeStopReden,
    //        Opmerking = cmd.Opmerking
    //    });
    //}

    //public void Stopbehandelplan(StopBehandelplan cmd)
    //{
    //    GliStatus = GliStatus.Gestopt;
    //    VoortijdigGestopt = true;
    //    VoortijdigeStopdatum = cmd.VoortijdigeStopdatum;
    //    RedenEindeZorgId = cmd.RedenEindeZorgId;
    //}


    //public void VerwijderBehandeltraject(VerwijderBehandeltraject cmd)
    //{
    //    AddAndApplyEvent(new BehandeltrajectVerwijderd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,
    //        Status = "Verwijderd"
    //    });
    //}

    //public void Verwerk(VerwerkBehandelplan cmd)
    //{
    //    VerwerktOp = cmd.VerwerktOp;
    //    GliStatus = cmd.Status;

    //    AddAndApplyEvent(new BehandelplanVerwerkt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Verwerkt = "Ja",
    //        VerwerktOp = cmd.VerwerktOp.ToString("dd-MM-yyyy"),
    //        Status = cmd.Status.ToString()
    //    });
    //}

    //public void WijzigBehandelplanStatus(WijzigBehandelplanStatus cmd)
    //{
    //    GliStatus = cmd.Status;
    //}


    //#region Private methods

    //private void Apply(BehandeltrajectGestart @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Opmerking = @event.Opmerking;
    //}

    //private void Apply(BehandeltrajectGestopt @event)
    //{
    //    VoortijdigGestopt = true;
    //    Opmerking = @event.Opmerking;
    //    GliStatus = GliStatus.Gestopt;
    //}

    //private void Apply(BehandeltrajectVerwijderd @event)
    //{
    //    GliStatus = GliStatus.Verwijderd;
    //}

    //private void Apply(BehandelplanVerwerkt @event)
    //{
    //    Verwerkt = true;
    //}


    //#endregion
}

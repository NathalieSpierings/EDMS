using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Intake;

public class GliIntake : AggregateRoot
{
    /// <summary>
    /// The date of the intake.
    /// </summary>
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

    public Guid BehandelaarId { get; set; }
    public virtual Medewerker Behandelaar { get; set; }
    
    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie Organisatie { get; set; }

    public virtual ICollection<GliBehandelplan> Behandelplannen { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty GLI intake.
    /// </summary>
    public GliIntake()
    {

    }

    //public GliIntake(NieuweIntake cmd)
    //{
    //    IntakeDatum = cmd.IntakeDatum;
    //    VerzekerdeId = cmd.VerzekerdeId;
    //    BehandelaarId = cmd.BehandelaarId;
    //    OrganisatieId = cmd.OrganisatieId;
    //    GliStatus = GliStatus.NogNietGestart;

    //    AddAndApplyEvent(new IntakeAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Lengte = $"{cmd.WeegMoment.Lengte} cm",
    //        Gewicht = $"{cmd.WeegMoment.Gewicht} KG",
    //        Opnamedatum = cmd.WeegMoment.Opnamedatum.ToString("dd-MM-yyyy"),
    //        IntakeDatum = cmd.IntakeDatum.ToString("dd-MM-yyyy"),
    //        Opmerking = cmd.Opmerking
    //    });
    //}

    //public void UpdateIntake(WijzigIntake cmd)
    //{
    //    IntakeDatum = cmd.IntakeDatum;
    //    BehandelaarId = cmd.BehandelaarId;

    //    AddAndApplyEvent(new IntakeGewijzigd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Lengte = $"{cmd.WeegMoment.Lengte} cm",
    //        Gewicht = $"{cmd.WeegMoment.Gewicht} KG",
    //        Opnamedatum = cmd.WeegMoment.Opnamedatum.ToString("dd-MM-yyyy"),
    //        IntakeDatum = cmd.IntakeDatum.ToString("dd-MM-yyyy"),
    //        Opmerking = cmd.Opmerking
    //    });
    //}

    //public void Verwerk(VerwerkIntake cmd)
    //{
    //    VerwerktOp = cmd.VerwerktOp;

    //    AddAndApplyEvent(new IntakeVerwerkt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Verwerkt = "Ja",
    //        VerwerktOp = cmd.VerwerktOp.ToString("dd-MM-yyyy")
    //    });
    //}

    //public void UpdateIntakeStatus(WijzigIntakeStatus cmd)
    //{
    //    GliStatus = cmd.GliStatus;

    //    AddAndApplyEvent(new IntakeStatusGewijzigd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Status = cmd.GliStatus.ToString()
    //    });
    //}

    //#region Private methods

    //private void Apply(IntakeAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Opmerking = @event.Opmerking;
    //}

    //private void Apply(IntakeGewijzigd @event)
    //{
    //    Opmerking = @event.Opmerking;
    //}

    //private void Apply(IntakeStatusGewijzigd @event)
    //{
    //}

    //private void Apply(IntakeVerwerkt @event)
    //{
    //    Verwerkt = true;
    //}

    //#endregion
}

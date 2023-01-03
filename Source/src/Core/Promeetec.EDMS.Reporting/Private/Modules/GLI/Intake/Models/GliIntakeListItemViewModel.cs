using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

public class GliIntakeListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid VerzekerdeId { get; set; }
    public string VerzekerdeFormeleNaam { get; set; }
    public string Bsn { get; set; }
    public string AgbCodeVerwijzer { get; set; }
    public string NaamVerwijzer { get; set; }
    public Guid IntakeId { get; set; }
    public DateTime IntakeDatum { get; set; }
    public bool Verwerkt { get; set; }
    public DateTime? VerwerktOp { get; set; }
    public bool BehandeltrajectGestart { get; set; }
}
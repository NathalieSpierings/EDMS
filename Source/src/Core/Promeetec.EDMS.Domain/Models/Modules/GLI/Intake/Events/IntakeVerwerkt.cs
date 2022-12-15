using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Events;

public class IntakeVerwerkt : EventBase
{
    public string Verwerkt { get; set; }
    public string VerwerktOp { get; set; }
}
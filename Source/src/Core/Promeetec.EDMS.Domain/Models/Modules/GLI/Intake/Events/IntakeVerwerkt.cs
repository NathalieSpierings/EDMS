using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Events;

public class IntakeVerwerkt : EventBase
{
    public string Verwerkt { get; set; }
    public string VerwerktOp { get; set; }
}
using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

public class ProcessIntake : CommandBase
{
    public DateTime VerwerktOp { get; set; }
}
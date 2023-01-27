using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

public class UpdateIntakeStatus : CommandBase
{
    public Behandelplan.GliStatus GliStatus { get; set; }
}
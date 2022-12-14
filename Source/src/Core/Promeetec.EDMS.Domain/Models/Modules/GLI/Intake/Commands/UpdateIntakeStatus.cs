using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;

public class UpdateIntakeStatus : CommandBase
{
    public GliStatus GliStatus { get; set; }
}
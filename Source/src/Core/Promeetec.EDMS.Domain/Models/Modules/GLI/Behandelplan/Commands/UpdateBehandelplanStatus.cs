using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;

public class UpdateBehandelplanStatus : CommandBase
{
    public GliStatus Status { get; set; }
}
using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;

public class UpdateBehandelplanStatus : CommandBase
{
    public GliStatus Status { get; set; }
}
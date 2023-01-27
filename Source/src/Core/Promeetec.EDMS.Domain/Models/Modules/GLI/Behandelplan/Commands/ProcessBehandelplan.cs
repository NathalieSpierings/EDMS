using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;

public class ProcessBehandelplan : CommandBase
{
    public DateTime VerwerktOp { get; set; }
    public GliStatus Status { get; set; }
}
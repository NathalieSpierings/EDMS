using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;

public class ProcessBehandelplan : CommandBase
{
    public DateTime VerwerktOp { get; set; }
    public GliStatus Status { get; set; }
}
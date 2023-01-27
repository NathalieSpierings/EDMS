using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Events;

public class BehandelplanVerwerkt : EventBase
{
    public string Verwerkt { get; set; }
    public string VerwerktOp { get; set; }
    public string Status { get; set; }
}
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Events;

public class BehandelplanVerwerkt : EventBase
{
    public string Verwerkt { get; set; }
    public string VerwerktOp { get; set; }
    public string Status { get; set; }
}
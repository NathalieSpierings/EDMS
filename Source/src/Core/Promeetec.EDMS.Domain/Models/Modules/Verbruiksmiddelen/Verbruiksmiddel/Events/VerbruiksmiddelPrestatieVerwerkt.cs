using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;

public class VerbruiksmiddelPrestatieVerwerkt : EventBase
{
    public string Status { get; set; }
}
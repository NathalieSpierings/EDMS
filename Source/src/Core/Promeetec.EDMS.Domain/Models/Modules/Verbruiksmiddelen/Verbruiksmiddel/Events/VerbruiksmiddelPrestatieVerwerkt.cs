using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;

public class VerbruiksmiddelPrestatieVerwerkt : EventBase
{
    public string Status { get; set; }
}
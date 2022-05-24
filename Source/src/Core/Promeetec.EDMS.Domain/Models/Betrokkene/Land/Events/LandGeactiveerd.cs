using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;

public class LandGeactiveerd : EventBase
{
    public string Status { get; set; }
}
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;

public class LandVerwijderd : EventBase
{
    public string Status { get; set; }
}
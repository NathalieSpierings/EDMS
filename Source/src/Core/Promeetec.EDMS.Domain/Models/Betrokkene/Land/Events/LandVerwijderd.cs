using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Events;

public class LandVerwijderd : EventBase
{
    public string Status { get; set; }
}
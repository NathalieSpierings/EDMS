using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerVerwijderd : EventBase
{
    public string Status { get; set; }
}

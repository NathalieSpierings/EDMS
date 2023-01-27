using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGedeactiveerd : EventBase
{
    public string Status { get; set; }
}

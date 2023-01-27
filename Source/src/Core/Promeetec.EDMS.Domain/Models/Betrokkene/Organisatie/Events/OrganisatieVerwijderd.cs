using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieVerwijderd : EventBase
{
    public string Status { get; set; }
}

using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGeblokkeerd : EventBase
{
    public string RedeBlokkade { get; set; }

}

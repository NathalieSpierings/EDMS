using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGedeactiveerd : EventBase
{
    public string Status { get; set; }
}

using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGeactiveerd : EventBase
{
	public string Status { get; set; }
}

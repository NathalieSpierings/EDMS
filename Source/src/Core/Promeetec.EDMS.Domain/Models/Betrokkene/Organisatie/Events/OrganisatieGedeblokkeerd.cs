using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGedeblokkeerd : EventBase
{
	public string Geblokkeerd { get; set; }
}

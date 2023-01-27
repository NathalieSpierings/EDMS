using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGedeblokkeerd : EventBase
{
	public string Geblokkeerd { get; set; }
}

using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerGedeactiveerd : EventBase
{
	public string Status { get; set; }
}

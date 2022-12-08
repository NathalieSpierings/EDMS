using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerGeactiveerd : EventBase
{
	public string Status { get; set; }
}

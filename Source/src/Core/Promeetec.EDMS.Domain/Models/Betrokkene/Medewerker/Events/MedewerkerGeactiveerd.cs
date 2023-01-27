using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerGeactiveerd : EventBase
{
	public string Status { get; set; }
}

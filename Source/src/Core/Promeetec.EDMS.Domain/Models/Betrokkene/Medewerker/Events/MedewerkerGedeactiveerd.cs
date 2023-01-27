using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerGedeactiveerd : EventBase
{
	public string Status { get; set; }
}

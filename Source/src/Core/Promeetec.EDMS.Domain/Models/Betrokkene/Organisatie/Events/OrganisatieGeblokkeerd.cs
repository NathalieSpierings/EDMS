using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGeblokkeerd : EventBase
{
    public string Geblokkeerd { get; set; }
    public string BlokkeerReden { get; set; }

}

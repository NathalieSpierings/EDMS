using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGeblokkeerd : EventBase
{
    public string Geblokkeerd { get; set; }
    public string BlokkeerReden { get; set; }

}

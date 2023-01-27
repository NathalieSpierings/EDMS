using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerToegevoegdAanGroep : EventBase
{
    public string GroupName { get; set; }
}

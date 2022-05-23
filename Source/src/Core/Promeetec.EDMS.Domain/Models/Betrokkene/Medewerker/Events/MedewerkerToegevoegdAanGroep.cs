using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerToegevoegdAanGroep : EventBase
{
    public string GroupName { get; set; }
}

using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerToegevoegdAanGroep : EventBase
{
    public GroupUser GroupUser { get; set; }
}

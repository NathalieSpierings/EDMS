using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerIngelogd : EventBase
{
    public DateTime? LaatstIngelogdOp { get; set; }
    public DateTime? VorigeLoginOp { get; set; }
    public string UserHostAddress { get; set; }
    public string UserAgent { get; set; }
}

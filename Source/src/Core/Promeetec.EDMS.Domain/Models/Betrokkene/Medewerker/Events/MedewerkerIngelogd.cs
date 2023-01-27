using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerIngelogd : EventBase
{
    public DateTime? LaatstIngelogdOp { get; set; }
    public DateTime? VorigeLoginOp { get; set; }
    public string UserHostAddress { get; set; }
    public string UserAgent { get; set; }
}

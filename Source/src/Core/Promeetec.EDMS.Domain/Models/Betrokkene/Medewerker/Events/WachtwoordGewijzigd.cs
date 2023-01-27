using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class WachtwoordGewijzigd : EventBase
{
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
}

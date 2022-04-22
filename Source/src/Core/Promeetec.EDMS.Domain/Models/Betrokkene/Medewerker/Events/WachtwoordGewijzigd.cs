using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class WachtwoordGewijzigd : EventBase
{
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
}

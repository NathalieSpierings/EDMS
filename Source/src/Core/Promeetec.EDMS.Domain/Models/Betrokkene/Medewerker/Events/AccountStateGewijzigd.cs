using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class AccountStateGewijzigd : EventBase
{
    public string AccountStatus { get; set; }
}

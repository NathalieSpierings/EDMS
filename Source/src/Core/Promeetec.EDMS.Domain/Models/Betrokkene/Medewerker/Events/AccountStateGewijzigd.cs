using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class AccountStateGewijzigd : EventBase
{
    public string AccountStatus { get; set; }
}

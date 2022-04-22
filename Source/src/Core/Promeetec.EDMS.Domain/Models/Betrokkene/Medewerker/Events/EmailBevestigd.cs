using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class EmailBevestigd : EventBase
{
    public string AccountState { get; set; }
    public string EmailIsBevestigd { get; set; }

}

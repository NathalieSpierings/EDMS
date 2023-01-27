using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Events;

public class EmailBevestigd : EventBase
{
    public string AccountState { get; set; }
    public string EmailIsBevestigd { get; set; }

}

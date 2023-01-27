using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;

public class MenuVerwijderd : EventBase
{
    public string Status { get; set; }
}
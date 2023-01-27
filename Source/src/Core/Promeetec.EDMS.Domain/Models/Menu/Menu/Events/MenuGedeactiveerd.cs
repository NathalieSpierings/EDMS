using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;

public class MenuGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
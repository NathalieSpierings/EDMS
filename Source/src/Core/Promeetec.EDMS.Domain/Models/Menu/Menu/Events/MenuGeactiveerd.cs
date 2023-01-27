using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;

public class MenuGeactiveerd : EventBase
{
    public string Status { get; set; }
}
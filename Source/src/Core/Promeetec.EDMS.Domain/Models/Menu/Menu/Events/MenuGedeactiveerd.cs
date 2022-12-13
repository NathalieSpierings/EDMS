using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Events;

public class MenuGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
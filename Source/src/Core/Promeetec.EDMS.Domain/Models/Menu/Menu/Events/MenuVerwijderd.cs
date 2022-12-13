using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Events;

public class MenuVerwijderd : EventBase
{
    public string Status { get; set; }
}
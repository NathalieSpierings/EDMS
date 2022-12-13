using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Events;

public class MenuGeactiveerd : EventBase
{
    public string Status { get; set; }
}
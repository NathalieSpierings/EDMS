using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Events;

public class MenuAangemaakt : EventBase
{
    public string Status { get; set; }
    public string Naam { get; set; }
    public string Soort { get; set; }
}
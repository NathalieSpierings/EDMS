using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Events;

public class MenuGewijzigd : EventBase
{
    public string Soort { get; set; }
    public string Naam { get; set; }
}
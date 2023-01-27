using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;

public class MenuGewijzigd : EventBase
{
    public string Soort { get; set; }
    public string Naam { get; set; }
}
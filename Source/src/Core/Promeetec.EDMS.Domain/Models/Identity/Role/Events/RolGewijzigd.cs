using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;

public class RolGewijzigd : EventBase
{
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Role.Events;

public class RolGewijzigd : EventBase
{
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}
using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;

public class RolAangemaakt : EventBase
{
    public string Status { get; set; }
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}
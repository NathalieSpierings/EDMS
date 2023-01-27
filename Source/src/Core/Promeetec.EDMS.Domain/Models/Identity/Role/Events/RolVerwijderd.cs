using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;

public class RolVerwijderd : EventBase
{
    public string Status { get; set; }
}
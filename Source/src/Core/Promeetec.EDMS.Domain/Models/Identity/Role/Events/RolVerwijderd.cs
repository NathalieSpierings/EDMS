using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Role.Events;

public class RolVerwijderd : EventBase
{
    public string Status { get; set; }
}
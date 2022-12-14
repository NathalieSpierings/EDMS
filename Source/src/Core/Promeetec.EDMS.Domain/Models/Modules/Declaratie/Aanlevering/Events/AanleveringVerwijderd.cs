using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Events;

public class AanleveringVerwijderd : EventBase
{
    public string Status { get; set; }
}
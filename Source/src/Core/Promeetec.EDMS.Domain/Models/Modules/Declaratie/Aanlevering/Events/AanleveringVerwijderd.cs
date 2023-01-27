using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;

public class AanleveringVerwijderd : EventBase
{
    public string Status { get; set; }
}
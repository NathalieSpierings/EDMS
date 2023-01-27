using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;

public class EigenaarAanleveringGewijzigd : EventBase
{
    public string Eigenaar { get; set; }
    public Guid EigenaarId { get; set; }
}
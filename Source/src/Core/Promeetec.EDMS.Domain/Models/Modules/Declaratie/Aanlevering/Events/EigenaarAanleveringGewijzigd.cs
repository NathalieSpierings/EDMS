using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Events;

public class EigenaarAanleveringGewijzigd : EventBase
{
    public string Eigenaar { get; set; }
    public Guid EigenaarId { get; set; }
}
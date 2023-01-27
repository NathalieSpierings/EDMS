using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Events;

public class VerzekerdeGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
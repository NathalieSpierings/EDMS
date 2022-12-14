using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Events;

public class VerzekerdeGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
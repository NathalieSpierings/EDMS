using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
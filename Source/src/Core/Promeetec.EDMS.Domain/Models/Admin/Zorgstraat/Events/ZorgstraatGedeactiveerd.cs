using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatGedeactiveerd : EventBase
{
    public string Status { get; set; }
}
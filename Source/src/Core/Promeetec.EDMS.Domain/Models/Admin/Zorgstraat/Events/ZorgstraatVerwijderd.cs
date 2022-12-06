using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatVerwijderd : EventBase
{
    public string Status { get; set; }
}
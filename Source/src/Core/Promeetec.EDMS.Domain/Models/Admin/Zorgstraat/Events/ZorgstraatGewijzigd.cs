using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatGewijzigd : EventBase
{
    public string Naam { get; set; }
}
using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Events;

public class LandGewijzigd : EventBase
{
    public string CultureCode { get; set; }
    public string? NativeName { get; set; }
}
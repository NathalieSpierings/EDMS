using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Events;

public class LandAangemaakt : EventBase
{
    public string Status { get; set; }
    public string CultureCode { get; set; }
    public string? NativeName { get; set; }
}
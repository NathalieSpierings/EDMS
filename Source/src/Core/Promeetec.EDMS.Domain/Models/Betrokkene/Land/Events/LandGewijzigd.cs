using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;

public class LandGewijzigd : EventBase
{
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
}
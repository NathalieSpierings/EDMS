namespace Promeetec.EDMS.Domain.Betrokkene.Land.Events;

public class LandGewijzigd : DomainEvent
{
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
}
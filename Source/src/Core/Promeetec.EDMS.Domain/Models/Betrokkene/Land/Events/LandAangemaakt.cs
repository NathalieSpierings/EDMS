namespace Promeetec.EDMS.Domain.Betrokkene.Land.Events;

public class LandAangemaakt : DomainEvent
{
    public string Status { get; set; }
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
}
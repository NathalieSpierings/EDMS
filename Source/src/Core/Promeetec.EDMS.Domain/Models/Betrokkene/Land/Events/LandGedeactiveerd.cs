namespace Promeetec.EDMS.Domain.Betrokkene.Land.Events;

public class LandGedeactiveerd : DomainEvent
{
    public string Status { get; set; }
}
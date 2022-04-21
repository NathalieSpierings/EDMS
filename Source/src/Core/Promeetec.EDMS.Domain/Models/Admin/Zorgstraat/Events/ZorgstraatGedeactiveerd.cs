namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Events;

public class ZorgstraatGedeactiveerd : DomainEvent
{
    public string Status { get; set; }
}
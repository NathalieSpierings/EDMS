namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Events;

public class ZorgstraatGeactiveerd : DomainEvent
{
    public string Status { get; set; }
}
namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Events;

public class ZorgstraatVerwijderd : DomainEvent
{
    public string Status { get; set; }
}
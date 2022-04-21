namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Events;

public class ZorgstraatGewijzigd : DomainEvent
{
    public string Naam { get; set; }
}
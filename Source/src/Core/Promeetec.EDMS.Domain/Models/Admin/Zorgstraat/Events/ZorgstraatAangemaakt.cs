namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Events;

public class ZorgstraatAangemaakt : DomainEvent
{
    public string Status { get; set; }
    public string Naam { get; set; }
}
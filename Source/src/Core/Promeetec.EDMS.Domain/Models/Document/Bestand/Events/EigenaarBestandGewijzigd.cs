namespace Promeetec.EDMS.Domain.Document.Bestand.Events
{
    public class EigenaarBestandGewijzigd : DomainEvent
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
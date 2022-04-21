namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Events
{
    public class EigenaarAanleveringGewijzigd : DomainEvent
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
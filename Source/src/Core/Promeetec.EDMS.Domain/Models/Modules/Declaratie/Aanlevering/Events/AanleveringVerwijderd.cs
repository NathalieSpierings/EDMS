namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Events
{
    public class AanleveringVerwijderd : DomainEvent
    {
        public string Status { get; set; }
    }
}
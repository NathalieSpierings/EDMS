namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Events
{
    public class AanleveringGewijzigd : DomainEvent
    {
        public string ReferentiePromeetec { get; set; }
        public string AanleverStatus { get; set; }
        public string ToevoegenBestand { get; set; }
        public string Behandelaar { get; set; }
        public string Eigenaar { get; set; }
        public string Opmerking { get; set; }
    }
}
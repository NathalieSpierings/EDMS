namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Events
{
    public class AanleveringAangemaakt : DomainEvent
    {
        public string Organisatie { get; set; }
        public string Behandelaar { get; set; }
        public string Eigenaar { get; set; }
        public string Status { get; set; }
        public int Jaar { get; set; }
        public DateTime Aanleverdatum { get; set; }
        public string Referentie { get; set; }
        public string ReferentiePromeetec { get; set; }
        public string AanleverStatus { get; set; }
        public string ToevoegenBestand { get; set; }
        public string Opmerking { get; set; }
    }
}
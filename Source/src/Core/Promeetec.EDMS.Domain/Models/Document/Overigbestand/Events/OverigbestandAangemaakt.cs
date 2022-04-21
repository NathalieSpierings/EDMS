namespace Promeetec.EDMS.Domain.Document.Overigbestand.Events
{
    public class OverigbestandAangemaakt : DomainEvent
    {
        public Guid AanleveringId { get; set; }
        public string ReferentiePromeetec { get; set; }
        public string Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
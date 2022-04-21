namespace Promeetec.EDMS.Domain.Document.Bestand.Events
{
    public class BestandAangemaakt : DomainEvent
    {
        public string Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }
        public string Extensie { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
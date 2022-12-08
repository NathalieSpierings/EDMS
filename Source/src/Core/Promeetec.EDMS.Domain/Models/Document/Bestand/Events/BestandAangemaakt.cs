using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Events
{
    public class BestandAangemaakt : EventBase
    {
        public string? Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }
        public string? Extensie { get; set; }
        public string? MimeType { get; set; }
        public Guid EigenaarId { get; set; }
        public string Eigenaar { get; set; }
    }
}
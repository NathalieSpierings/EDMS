using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Events
{
    public class BestandGewijzigd : EventBase
    {
        public string Bestandsnaam { get; set; }
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }

    }
}
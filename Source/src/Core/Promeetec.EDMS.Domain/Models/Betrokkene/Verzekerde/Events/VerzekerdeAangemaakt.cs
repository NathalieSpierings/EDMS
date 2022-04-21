using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Events
{
    public class VerzekerdeAangemaakt : DomainEvent
    {
        public string Bsn { get; set; }
        public Persoon.Persoon Persoon { get; set; }
        public virtual Zorgprofiel Zorgprofiel { get; set; }
        public string AgbCodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public string Verwijsdatum { get; set; }
    }
}
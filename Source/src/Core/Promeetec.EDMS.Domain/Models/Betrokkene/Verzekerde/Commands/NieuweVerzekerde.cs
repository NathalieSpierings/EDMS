using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands
{
    public class NieuweVerzekerde : DomainCommand<Verzekerde>
    {
        public string Bsn { get; set; }
        public Persoon.Persoon Persoon { get; set; }
        public Adres.Adres Adres { get; set; }
        public Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }
        public Zorgprofiel Zorgprofiel { get; set; }
        public Guid AdresboekId { get; set; }
        public string AgbCodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public DateTime? Verwijsdatum { get; set; }
    }
}
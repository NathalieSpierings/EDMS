using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class UpdateVerzekerde : CommandBase
    {
        public string Bsn { get; set; }
        public Persoon.Persoon Persoon { get; set; } = new Persoon.Persoon();
        public Adres.Adres Adres { get; set; }
        public Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }
        public Zorgprofiel? Zorgprofiel { get; set; }
        public string AgbCodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public DateTime? Verwijsdatum { get; set; }
    }
}
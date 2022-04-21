using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events
{
    public class VerbruiksmiddelPrestatieAangemaakt : DomainEvent
    {
        public string AgbCodeOnderneming { get; set; }
        public HulpmiddelenSoort HulpmiddelenSoort { get; set; }
        public VerbruiksmiddelPrestatieStatus Status { get; set; }
        public int? VerwerkMaand { get; set; }
        public int? VerwerkJaar { get; set; }
        public ProfielCode? ProfielCode { get; set; }
        public DateTime? ProfielStartdatum { get; set; }
        public DateTime? ProfielEinddatum { get; set; }
        public int? ZIndex { get; set; }
        public DateTime? PrestatieDatum { get; set; }
        public int? Hoeveelheid { get; set; }
        public Guid EigenaarId { get; set; }
        public Guid VerzekerdeId { get; set; }
        public Guid OrganisatieId { get; set; }
    }
}
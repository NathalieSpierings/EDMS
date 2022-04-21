namespace Promeetec.EDMS.Domain.Modules.ION.Events
{
    public class PatientRelatieAangemaakt : DomainEvent
    {
        public DateTime Periode { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public string AgbCodePraktijk { get; set; }
        public string Kwaliteitscategorie { get; set; }
        public string PatientrelatiesZoekoptie { get; set; }

        public int AantalRelaties { get; set; }
        public string Verwerkt { get; set; }
        public Guid MedewerkerId { get; set; }
        public Guid OrganisatieId { get; set; }
        public DateTime AangeleverdOp { get; set; }

        public Guid? ZorggroepRelatieId { get; set; }
    }
}
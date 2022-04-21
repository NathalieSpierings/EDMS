namespace Promeetec.EDMS.Domain.Models.Modules.ION
{
    public class IONPopulatieDto
    {
        public Guid Id { get; set; }
        public Guid OrganisatieId { get; set; }
        public Guid MedewerkerId { get; set; }
        public Guid? ZorggroepRelatieId { get; set; }
        public Guid RaadplegerId { get; set; }
        public string RaadplegerNaam { get; set; }
        public DateTime Periode { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public string AgbCodeOnderneming { get; set; }
        public IONZoekOptie IONZoekOptie { get; set; }
        public DateTime AangeleverdOp { get; set; }
        public bool Verwerkt { get; set; }
        public int Relaties { get; set; }
        public string Voorletters { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Bsn { get; set; }

    }
}
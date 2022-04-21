namespace Promeetec.EDMS.Domain.Models.Modules.ION
{
    public class IONPatient
    {
        public long Key { get; set; }
        public long RelatieId { get; set; }
        public string Bsn { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Voorletters { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Kwaliteitscategorie { get; set; }
        public string PatientrelatiesZoekoptie { get; set; }

        public string AgbCodePraktijk { get; set; }
    }

    public class IONJsonResult
    {
        public Guid MedewerkerId { get; set; }
        public Guid OrganisatieId { get; set; }
        public IONZoekOptie ZoekOptie { get; set; }

        public string Periode { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public string AgbCodePraktijk { get; set; }
        public int AantalRelaties { get; set; }
        public List<IONPatient> Relaties { get; set; } = new List<IONPatient>();
    }

    public class IONResultDS
    {
        public Guid OrganisatieId { get; set; }
        public string Periode { get; set; }
        public int AantalRelaties { get; set; }
        public List<IONJsonResult> IONResults { get; set; } = new List<IONJsonResult>();
    }
}

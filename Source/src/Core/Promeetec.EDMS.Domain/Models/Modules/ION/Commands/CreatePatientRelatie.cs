namespace Promeetec.EDMS.Domain.Modules.ION.Commands
{
    public class CreatePatientRelatie : DomainCommand<IONPatientRelatie>
    {
        public DateTime Periode { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public string AgbCodePraktijk { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Voorletters { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Bsn { get; set; }
        public Kwaliteitscategorie Kwaliteitscategorie { get; set; }
        public IONZoekOptie IONZoekOptie { get; set; }
        public int AantalRelaties { get; set; }
        public Guid MedewerkerId { get; set; }
        public Guid OrganisatieId { get; set; }
        public Guid? ZorggroepRelatieId { get; set; }
    }
}
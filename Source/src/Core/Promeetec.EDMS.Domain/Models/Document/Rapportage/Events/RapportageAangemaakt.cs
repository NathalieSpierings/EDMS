namespace Promeetec.EDMS.Domain.Document.Rapportage.Events
{
    public class RapportageAangemaakt : DomainEvent
    {
        public string ReferentiePromeetec { get; set; }
        public string Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }
        public string Eigenaar { get; set; }
        public Guid OrganisatieId { get; set; }
        public string Organisatie { get; set; }
        public string RapportageSoort { get; set; }
    }
}
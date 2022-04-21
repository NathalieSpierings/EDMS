namespace Promeetec.EDMS.Domain.Document.Rapportage.Commands
{
    public class SendEmailRapportageToegevoegd
    {
        public string BaseUrl { get; set; }
        public string Titel => "Rapportage(en) toegevoegd";
        public string Onderwerp => $"Rapportage(s) met ref: {ReferentiePromeetec} toegevoegd aan uw organisatie '{OrganisatieNaam}'";
        public Guid OrganisatieId { get; set; }
        public string OrganisatieNaam { get; set; }
        public Guid OntvangerId { get; set; }
        public string OntvangerNaam { get; set; }
        public string OntvangerEmail { get; set; }
        public Guid ContactpersoonId { get; set; }
        public string ContactpersoonNaam { get; set; }
        public string ContactpersoonEmail { get; set; }
        public string ContactpersoonTel { get; set; }
        public string ReferentiePromeetec { get; set; }
    }
}
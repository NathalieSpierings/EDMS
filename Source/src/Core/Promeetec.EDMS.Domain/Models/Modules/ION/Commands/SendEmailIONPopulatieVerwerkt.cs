namespace Promeetec.EDMS.Domain.Modules.ION.Commands
{
    public class SendEmailIONPopulatieVerwerkt
    {
        public string BaseUrl { get; set; }
        public string Titel => "ION-populatie opgehaald en vewerkt";
        public string Onderwerp => "ION-populatie opgehaald en verwerkt";

        public string NamensOrganisatie { get; set; }
        public string OrganisatieNaam { get; set; }
        public string Contactpersoon { get; set; }
        public string ContactpersoonEmail { get; set; }
        public string ContactpersoonTel { get; set; }
        public string Ontvanger { get; set; }
        public string OntvangerEmail { get; set; }
        public DateTime Periode { get; set; }
        public int AantalRelaties { get; set; }
        public string AgbCodeOnderneming { get; set; }
    }
}
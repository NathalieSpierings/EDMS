using System.Net.Mail;
using Promeetec.EDMS.Domain.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands
{
    public class SendEmailAntwoordOpHoofdbericht : DomainCommand<Aanleverbericht>
    {
        public Guid BerichtId { get; set; }
        public string BaseUrl { get; set; }
        public Guid HoofdberichtId { get; set; }
        public Guid OntvangerId { get; set; }
        public string OntvangerNaam { get; set; }
        public string OntvangerEmail { get; set; }
        public EmailOntvangenType OntvangerEmailVoorkeur { get; set; }
        public Guid AfzenderId { get; set; }
        public string AfzenderNaam { get; set; }
        public string AfzenderEmail { get; set; }
        public EmailOntvangenType AfzenderEmailVoorkeur { get; set; }
        public Guid AanleveringId { get; set; }
        public Guid EigenaarId { get; set; }
        public string Referentie { get; set; }
        public Guid OrganisatieId { get; set; }
        public string OrganisatieNaam { get; set; }
        public Guid BehandelaarId { get; set; }
        public string BehandelaarNaam { get; set; }
        public string BehandelaarEmail { get; set; }
        public string BehandelaarTel { get; set; }
        public EmailOntvangenType BehandelaarEmailVoorkeur { get; set; }
        public string Titel => "Aanleverbericht is beantwoord.";
        public string Onderwerp { get; set; }
        public List<MailAddress> CcMailAddresses { get; set; } = new List<MailAddress>();
    }
}
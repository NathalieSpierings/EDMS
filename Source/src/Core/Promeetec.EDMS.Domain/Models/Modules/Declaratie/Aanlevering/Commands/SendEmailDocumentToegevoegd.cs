using System.Net.Mail;
using Promeetec.EDMS.Domain.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands
{
    public class SendEmailDocumentToegevoegd
    {
        public string BaseUrl { get; set; }
        public Guid DocumentToevoegerId { get; set; }
        public EmailOntvangenType EmailVoorkeurDocumentToevoeger { get; set; }
        public Guid AanleveringId { get; set; }
        public string Referentie { get; set; }
        public Guid OrganisatieId { get; set; }
        public string OrganisatieNaam { get; set; }
        public Guid BehandelaarId { get; set; }
        public string BehandelaarNaam { get; set; }
        public string BehandelaarEmail { get; set; }
        public string BehandelaarTel { get; set; }
        public EmailOntvangenType BehandelaarEmailVoorkeur { get; set; }
        public Guid EigenaarId { get; set; }
        public string EigenaarNaam { get; set; }
        public string EigenaarEmail { get; set; }
        public EmailOntvangenType EmailVoorkeurEigenaar { get; set; }
        public string Titel => "Document(en) toegevoegd";
        public string Onderwerp => $"Document(en) toegevoegd aan aanlevering met Promeetec referentie '{Referentie}'";
        public List<MailAddress> CcMailAddresses { get; set; } = new List<MailAddress>();
    }
}
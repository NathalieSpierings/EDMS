using System.Net.Mail;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

public class SendEmailHoofdbericht : CommandBase
{
    public Guid BerichtId { get; set; }
    public string BaseUrl { get; set; }
    public Guid OntvangerId { get; set; }
    public string OntvangerNaam { get; set; }
    public string OntvangerEmail { get; set; }
    public Guid AfzenderId { get; set; }
    public string AfzenderNaam { get; set; }
    public string AfzenderEmail { get; set; }
    public Guid AanleveringId { get; set; }
    public Guid EigenaarId { get; set; }
    public string Referentie { get; set; }
    public string OrganisatieNaam { get; set; }
    public Guid BehandelaarId { get; set; }
    public string BehandelaarNaam { get; set; }
    public string BehandelaarEmail { get; set; }
    public string BehandelaarTel { get; set; }
    public EmailOntvangenType EmailVoorkeurOntvanger { get; set; }
    public string Titel => "Nieuw bericht geplaatst bij aanlevering.";
    public string Onderwerp => $"Nieuw bericht geplaatst op aanlevering met referentie: '{Referentie}'";
    public List<MailAddress> CcMailAddresses { get; set; } = new();
}
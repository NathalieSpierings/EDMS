using System.Net.Mail;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;

public class UpdateStatus
{
    public string Titel { get; set; }
    public string Onderwerp { get; set; }
    public string BaseUrl { get; set; }
    public Guid AanleveringId { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public string Referentie { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarNaam { get; set; }
    public string EigenaarEmail { get; set; }
    public string AanleveringStatusBerichtenIds { get; set; }
    public EmailOntvangenType EmailVoorkeurEigenaar { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string BehandelaarNaam { get; set; }
    public string BehandelaarEmail { get; set; }
    public string BehandelaarTel { get; set; }
    public EmailOntvangenType EmailVoorkeurContactpersoon { get; set; }
    public AanleverStatus OudeAanleverstatus { get; set; }
    public AanleverStatus NieuweAanleverstatus { get; set; }
    public List<MailAddress> CcMailAddresses { get; set; } = new();

}
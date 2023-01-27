using System.Net.Mail;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class SendEmailAanleveringAangemaakt
{
    public string BaseUrl { get; set; }
    public string Titel { get; set; }
    public string Onderwerp { get; set; }
    public Guid AanleveringId { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarNaam { get; set; }
    public string EigenaarEmail { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string BehandelaarNaam { get; set; }
    public string BehandelaarEmail { get; set; }
    public string BehandelaarTel { get; set; }

    public List<MailAddress> CcMailAddresses { get; set; } = new();

}
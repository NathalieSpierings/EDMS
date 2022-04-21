using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Events;

public class OrganisatieAangemaakt : EventBase
{
    public string Nummer { get; set; }
    public string Naam { get; set; }
    public string TelefoonZakelijk { get; set; }
    public string TelefoonPrive { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string Zorggroep { get; set; }
    public string IONZoekoptie { get; set; }
    public string AanleverbestandLocatie { get; set; }
    public string AanleverStatusNaSchrijvenAanleverbestanden { get; set; }
    public string COVControleType { get; set; }
    public string COVControleProcessType { get; set; }
}
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieAangemaakt : EventBase
{
    public string Nummer { get; set; }
    public string Naam { get; set; }
    public string? TelefoonZakelijk { get; set; }
    public string? TelefoonPrive { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool Zorggroep { get; set; }
    public string? AanleverbestandLocatie { get; set; }
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }
}

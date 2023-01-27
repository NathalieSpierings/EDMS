using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Events;

public class OrganisatieGewijzigd : EventBase
{
    public string Naam { get; set; }
    public string? TelefoonZakelijk { get; set; }
    public string? TelefoonPrive { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool Zorggroep { get; set; }
    public byte[] Logo { get; set; }
    public string? AanleverbestandLocatie { get; set; }
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }
}

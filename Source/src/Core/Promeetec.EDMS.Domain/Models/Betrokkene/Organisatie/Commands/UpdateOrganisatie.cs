using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class UpdateOrganisatie : CommandBase
{
    public string Naam { get; set; }
    public string TelefoonZakelijk { get; set; }
    public string TelefoonPrive { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool Zorggroep { get; set; }
    public byte[] Logo { get; set; }

    public OrganisatieSettings Settings { get; set; }

    public Guid? ZorggroepRelatieId { get; set; }
    public Guid? ContactpersoonId { get; set; }
    public Guid? AdresId { get; set; }
}

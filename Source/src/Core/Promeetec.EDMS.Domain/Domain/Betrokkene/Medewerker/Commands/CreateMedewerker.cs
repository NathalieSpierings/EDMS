using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Identity.Users;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker.Commands;

public class CreateMedewerker : DomainCommand<Medewerker>
{
    public Guid OrganisatieId { get; set; }
    public MedewerkerSoort MedewerkerSoort { get; set; }
    public EDMS.Domain.Betrokkene.Persoon.Persoon Persoon { get; set; } = new EDMS.Domain.Betrokkene.Persoon.Persoon();
    public string Functie { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string IONToestemmingsverklaringActivatieLink { get; set; }
    public byte[] Avatar { get; set; }
    public UserAccountState AccountState { get; set; }
    public string UserName { get; set; }
    public string TempCode { get; set; }
    public string PukCode { get; set; }
    public string ToegestaneIpAdressen { get; set; }
    public string OrganisatieDIsplayName { get; set; }
    public Adres.Adres Adres { get; set; }
}
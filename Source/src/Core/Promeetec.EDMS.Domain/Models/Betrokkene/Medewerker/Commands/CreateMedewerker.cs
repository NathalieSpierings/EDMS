using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Users;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

public class CreateMedewerker : CommandBase
{
    public MedewerkerSoort MedewerkerSoort { get; set; }
    public Persoon.Persoon Persoon { get; set; } = new Persoon.Persoon();
    public string Email { get; set; }
    public string Functie { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }

    public string IonToestemmingsverklaringActivatieLink { get; set; }
    public byte[] Avatar { get; set; }

    public UserAccountState AccountState { get; set; }
    public string UserName { get; set; }
    public string TempCode { get; set; }
    public string PukCode { get; set; }
    public string PasswordHash { get; set; }
    public Adres.Adres Adres { get; set; }
}

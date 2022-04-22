using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class UpdateMedewerker : CommandBase
{
    public Persoon.Persoon Persoon { get; set; } = new Persoon.Persoon();
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string Functie { get; set; }
    public string Email { get; set; }
    public byte[] Avatar { get; set; }
    public string IonToestemmingsverklaringActivatieLink { get; set; }
    public Adres.Adres Adres { get; set; }
}

using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class MedewerkerAangemaakt : EventBase
{
    public string Organisatie { get; set; }
    public string Status { get; set; }
    public string MedewerkerSoort { get; set; }
    public string Geslacht { get; set; }
    public string Voorletters { get; set; }
    public string? Tussenvoegsel { get; set; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string VollledigeNaam { get; set; }
    public string Gebruikersnaam { get; set; }
    public string Functie { get; set; }
    public string TelefoonZakelijk { get; set; }
    public string TelefoonPrive { get; set; }
    public string? Doorkiesnummer { get; set; }
    public string Email { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string IonToestemmingsverklaringActivatieLink { get; set; }
    public string? Adres { get; set; }
}

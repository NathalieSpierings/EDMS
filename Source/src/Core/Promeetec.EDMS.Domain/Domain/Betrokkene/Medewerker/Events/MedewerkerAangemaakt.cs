using OpenCqrs.Domain;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker.Events;

public class MedewerkerAangemaakt : DomainEvent
{
    public string Status { get; set; }
    public string Soort { get; set; }
    public string Geslacht { get; set; }
    public string VolledigeNaam { get; set; }
    public string Functie { get; set; }
    public string Email { get; set; }
    public string TelefoonZakelijk { get; set; }
    public string TelefoonPrive { get; set; }
    public string Doorkiesnummer { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string IONToestemmingsverklaringActivatieLink { get; set; }
    public string Organisatie { get; set; }
    public string Gebruikersnaam { get; set; }
    public string Adres { get; set; }
}
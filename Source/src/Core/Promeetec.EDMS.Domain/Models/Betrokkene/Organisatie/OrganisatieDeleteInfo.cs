namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

public class OrganisatieDeleteInfo : DeleteInfo
{
    public List<string> Voorraadbestanden { get; set; } = new();
    public List<string> Aanleveringen { get; set; } = new();
    public List<string> Aanleverbestanden { get; set; } = new();
    public List<string> Overigebestanden { get; set; } = new();
    public List<string> Rapportages { get; set; } = new();
    public List<MedewerkerDeleteInfo> Medewerkers { get; set; } = new();
    public EventsDeleteInfo Events { get; set; }
    public ModulesDeleteInfo Modules { get; set; }
    public AdresboekDeleteInfo Adresboek { get; set; }
}

public class MedewerkerDeleteInfo
{
    public string VolledigeNaam { get; set; }
    public string Email { get; set; }
    public int AantalMemos { get; set; }
    public int AantalNotificaties { get; set; }
}

public class AdresboekDeleteInfo : DeleteInfo
{
    public int AantalVerzekerden { get; set; }
    public int AantalVerzekerdenAdressen { get; set; }
    public int AantalZorgprofielen { get; set; }
}

public class ModulesDeleteInfo : DeleteInfo
{
    public int AantalGLIRegistraties { get; set; }
    public int AantalIONRelaties { get; set; }
    public int AantalVerbruiksmiddelPrestaties { get; set; }
}

public class EventsDeleteInfo : DeleteInfo
{
    public int AantalEvents { get; set; }
    public int AantalCommands { get; set; }
    public int AantalAggregates { get; set; }
}

public class DeleteInfo
{
    public DateTime Datum { get; set; }
    public string NaamVerwijderaar { get; set; }
    public string OrganisatieDisplayName { get; set; }
}
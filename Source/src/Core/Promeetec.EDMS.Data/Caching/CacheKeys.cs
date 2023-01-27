namespace Promeetec.EDMS.Portaal.Data.Caching;

public static class CacheKeys
{
    public static string CurrentOrganisatie(string organisatieNaam) => $"Current Organisatie | Naam: {organisatieNaam}";
}

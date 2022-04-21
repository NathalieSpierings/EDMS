namespace Promeetec.EDMS.Data.Caching;

public static class CacheKeys
{
    public static string CurrentOrganisatie(string organisatieNaam) => $"Current Organisatie | Naam: {organisatieNaam}";
    public static string Aanleveringen(Guid organisatieId) => $"Aanleveringen | OrganisatieId: {organisatieId}";
    public static string PermissionSet(Guid permissionSetId) => $"PermissionSet | PermissionSetId: {permissionSetId}";
}

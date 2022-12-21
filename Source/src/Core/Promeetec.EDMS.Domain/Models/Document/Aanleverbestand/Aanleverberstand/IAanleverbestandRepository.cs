using System.Security.Claims;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

public interface IAanleverbestandRepository : IRepository<Aanleverbestand>
{
    Aanleverbestand? GetAanleverbestandById(Guid id);
    Task<Aanleverbestand?> GetAanleverbestandByIdAsync(Guid id);
    Task<IList<Aanleverbestand>> GetAanleverbestandenByIdsAsync(List<Guid> ids);
    Task<IList<Aanleverbestand>> GetAanleverbestandenByAanleveringId(Guid aanleveringId, ClaimsPrincipal user);
    Task<int> AantalAanleverbestandenVanEigenaarAsync(Guid medewerkerId);

    bool CheckIfExists(int filesize, byte[] data, string filename, Guid organisatieId);
}
using Promeetec.EDMS.Domain.Models.Identity;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

public interface IAanleverbestandRepository : IRepository<Aanleverbestand>
{
    Aanleverbestand? GetAanleverbestandById(Guid id);
    Task<Aanleverbestand?> GetAanleverbestandByIdAsync(Guid id);
    Task<IList<Aanleverbestand>> GetAanleverbestandenByIdsAsync(List<Guid> ids);
    Task<IList<Aanleverbestand>> GetAanleverbestandenByAanleveringId(Guid aanleveringId, UserPrincipal user);
    Task<int> AantalAanleverbestandenVanEigenaarAsync(Guid medewerkerId);

    bool CheckIfExists(int filesize, byte[] data, string filename, Guid organisatieId);
}
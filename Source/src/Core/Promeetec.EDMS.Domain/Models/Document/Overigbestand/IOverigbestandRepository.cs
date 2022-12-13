using Promeetec.EDMS.Domain.Models.Identity;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand
{
    public interface IOverigBestandRepository : IRepository<Overigbestand>
    {
        bool DoesFileByFileNameExist(Guid aanleveringId, string fileName, UserPrincipal user);

        Overigbestand? GetOverigbestandByFileName(string fileName);

        bool CheckIfNameUnique(Guid aanleveringId, string filename, UserPrincipal user);
        Task<List<Overigbestand>> GetOverigbestandenByFileNameAsync(string fileName, Guid aanleveringId);
        Task<IList<Overigbestand>> GetOverigebestandenByIdsAsync(List<Guid> ids);
        Task<IList<Overigbestand>> GetOverigebestandenByAanleveringId(Guid aanleveringId, UserPrincipal user);
    }
}
using System.Security.Claims;
using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Overigbestand
{
    public interface IOverigBestandRepository : IRepository<Overigbestand>
    {
        bool DoesFileByFileNameExist(Guid aanleveringId, string fileName, ClaimsPrincipal user);

        Overigbestand? GetOverigbestandByFileName(string fileName);

        bool CheckIfNameUnique(Guid aanleveringId, string filename, ClaimsPrincipal user);
        Task<List<Overigbestand>> GetOverigbestandenByFileNameAsync(string fileName, Guid aanleveringId);
        Task<IList<Overigbestand>> GetOverigebestandenByIdsAsync(List<Guid> ids);
        Task<IList<Overigbestand>> GetOverigebestandenByAanleveringId(Guid aanleveringId, ClaimsPrincipal user);
    }
}
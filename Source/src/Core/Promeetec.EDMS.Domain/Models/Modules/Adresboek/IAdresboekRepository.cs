using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek
{
    public interface IAdresboekRepository : IRepository<Adresboek>
    {
        Task<Adresboek?> GetAdresboekWithVerzekerdenAsync(Guid adresboekId);
    }
}
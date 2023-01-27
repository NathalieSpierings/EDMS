using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage
{
    public interface IRapportageRepository : IRepository<Rapportage>
    {
        Task<Rapportage?> GetRapportageByIdsAsync(Guid id, Guid organisatieId);
        Task<IList<Rapportage>> GetRapportagesByIdsAsync(List<Guid> ids);
    }
}
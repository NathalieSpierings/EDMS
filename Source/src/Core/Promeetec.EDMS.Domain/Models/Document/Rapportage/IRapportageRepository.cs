﻿namespace Promeetec.EDMS.Domain.Document.Rapportage
{
    public interface IRapportageRepository : IRepository<Rapportage>
    {
        Task<Rapportage> GetRapportageByIdsAsync(Guid id, Guid organisatieId);
        Task<IList<Rapportage>> GetRapportagesByIdsAsync(List<Guid> ids);
    }
}
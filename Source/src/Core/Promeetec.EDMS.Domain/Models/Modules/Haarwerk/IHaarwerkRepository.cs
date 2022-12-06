namespace Promeetec.EDMS.Domain.Models.Modules.Haarwerk
{
    public interface IHaarwerkRepository : IRepository<Haarwerk>
    {
        Task<Haarwerk> GetHaarwerk(Guid id);
        Task<Haarwerk> GetHaarwerkVanOrganisatie(Guid id, Guid organisatieId);
        Task<List<Haarwerk>> GetVerwerkteHaarwerkenVanOrganisatie(Guid organisatieId, bool all);
        Task<List<Haarwerk>> GetNietVerwerkteHaarwerken(Guid organisatieId);
        Task<List<Haarwerk>> GetNietVerwerkteHaarwerken(Guid organisatieId, List<Guid> ids);
    }
}
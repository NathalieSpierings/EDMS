namespace Promeetec.EDMS.Domain.Models.Modules.Adresboek
{
    public interface IAdresboekRepository : IRepository<Adresboek>
    {
        Task<Adresboek?> GetAdresboekWithVerzekerdenAsync(Guid adresboekId);
    }
}
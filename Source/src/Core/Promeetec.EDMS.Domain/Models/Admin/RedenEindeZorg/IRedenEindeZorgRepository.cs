using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.RedenEindeZorg;

public interface IRedenEindeZorgRepository : IRepository<RedenEindeZorg>
{
    /// <summary>
    /// Gets the code and omschrijving by identifier asynchronous.
    /// </summary>
    /// <param name="id">The redeneindezorg identifier.</param>
    /// <returns>The code and omschrijving.</returns>
    Task<Dictionary<string, string>> GetCodeEnOmschrijvingByIdAsync(Guid id);
}
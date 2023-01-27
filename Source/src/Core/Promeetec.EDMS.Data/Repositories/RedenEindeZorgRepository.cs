using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class RedenEindeZorgRepository : Repository<RedenEindeZorg>, IRedenEindeZorgRepository
{
    public RedenEindeZorgRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, string>> GetCodeEnOmschrijvingByIdAsync(Guid id)
    {
        var dic = new Dictionary<string, string>();

        var dbQuery = await Query()
            .AsNoTracking()
            .Where(x => x.Id == id && x.Status == Status.Actief)
            .FirstOrDefaultAsync();

        if (dbQuery != null)
            dic.Add(dbQuery.Code, dbQuery.Omschrijving);

        return dic;
    }
}
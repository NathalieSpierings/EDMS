using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Data.Repositories;

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
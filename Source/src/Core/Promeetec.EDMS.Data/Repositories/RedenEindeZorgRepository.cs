using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.RedenEindeZorg;

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
        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.Id == id).FirstOrDefaultAsync();

        var dic = new Dictionary<string, string> { { dbQuery.Code, dbQuery.Omschrijving } };
        return dic;
    }
}
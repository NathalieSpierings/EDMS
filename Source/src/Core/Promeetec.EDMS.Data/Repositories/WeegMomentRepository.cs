using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment;

namespace Promeetec.EDMS.Data.Repositories;

public class WeegMomentRepository : Repository<Weegmoment>, IWeegMomentRepository
{
    public WeegMomentRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<List<Weegmoment>> GetWeegmomentenVanVerzekerdeAsync(Guid verzekerdeId)
    {
        var dbQuery = await Query().AsNoTracking().Where(x => x.VerzekerdeId == verzekerdeId).ToListAsync();
        return dbQuery;
    }

    /// <inheritdoc/>
    public async Task<Weegmoment?> GetLaasteWeegmomentVanVerzekerdeAsync(Guid verzekerdeId)
    {
        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.VerzekerdeId == verzekerdeId)
            .OrderByDescending(o => o.Opnamedatum).FirstOrDefaultAsync();

        return dbQuery;
    }
}
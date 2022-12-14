using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;

namespace Promeetec.EDMS.Data.Repositories;

public class AdresboekRepository : Repository<Adresboek>, IAdresboekRepository
{
    public AdresboekRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public async Task<Adresboek?> GetAdresboekWithVerzekerdenAsync(Guid adresboekId)
    {
        var dbQuery = await Query()
            .AsNoTracking()
            .Include(i => i.Verzekerden)
            .FirstOrDefaultAsync(x => x.Id == adresboekId);

        return dbQuery;
    }
}
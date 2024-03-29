﻿using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class WeegmomentRepository : Repository<Weegmoment>, IWeegmomentRepository
{
    public WeegmomentRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<List<Weegmoment>> GetWeegmomentenVanVerzekerdeAsync(Guid verzekerdeId)
    {
        var dbQuery = await Query()
            .AsNoTracking()
            .Where(x => x.VerzekerdeId == verzekerdeId)
            .ToListAsync();
        return dbQuery;
    }

    /// <inheritdoc/>
    public async Task<Weegmoment?> GetLaasteWeegmomentVanVerzekerdeAsync(Guid verzekerdeId)
    {
        var dbQuery = await Query()
            .AsNoTracking()
            .Where(x => x.VerzekerdeId == verzekerdeId)
            .OrderByDescending(o => o.Opnamedatum)
            .FirstOrDefaultAsync();

        return dbQuery;
    }
}
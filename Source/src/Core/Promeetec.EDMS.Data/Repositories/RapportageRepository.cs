using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class RapportageRepository : Repository<Rapportage>, IRapportageRepository
{
	public RapportageRepository(EDMSDbContext context)
		: base(context)
	{
	}

	public Task<Rapportage?> GetRapportageByIdsAsync(Guid id, Guid organisatieId)
	{
		var dbQuery = Query()
			.Include(i => i.Organisatie)
			.Include(i => i.Eigenaar)
			.Where(x => x.Id == id && x.OrganisatieId == organisatieId);
		return dbQuery.FirstOrDefaultAsync();
	}

	public async Task<IList<Rapportage>> GetRapportagesByIdsAsync(List<Guid> ids)
	{
		var dbQuery = Query()
			.Include(i => i.Organisatie)
			.Include(i => i.Eigenaar)
			.Where(x => ids.Contains(x.Id));
		return await dbQuery.ToListAsync();
	}
}
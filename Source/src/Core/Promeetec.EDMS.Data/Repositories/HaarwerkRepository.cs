using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk;

namespace Promeetec.EDMS.Portaal.Data.Repositories
{
    public class HaarwerkRepository : Repository<Haarwerk>, IHaarwerkRepository
    {
        public HaarwerkRepository(EDMSDbContext context)
            : base(context)
        {
        }

        public async Task<Haarwerk> GetHaarwerk(Guid id)
        {
            var dbQuery = await Query()
                .Include(i => i.Organisatie)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return dbQuery;
        }

        public async Task<Haarwerk> GetHaarwerkVanOrganisatie(Guid id, Guid organisatieId)
        {
            var dbQuery = await Query()
                .Include(i => i.Organisatie)
                .Where(x => x.Id == id && x.OrganisatieId == organisatieId)
                .FirstOrDefaultAsync();
            return dbQuery;
        }

        public async Task<List<Haarwerk>> GetVerwerkteHaarwerkenVanOrganisatie(Guid organisatieId, bool all)
        {
            var dbQuery = Query()
                .Include(i => i.Organisatie)
                .Where(x => x.OrganisatieId == organisatieId
                            && x.Status == HaarwerkStatus.Verwerkt);

            if (!all)
                dbQuery = dbQuery.Where(x => x.ExportedOn == null);

            return await dbQuery.ToListAsync();
        }

        public async Task<List<Haarwerk>> GetNietVerwerkteHaarwerken(Guid organisatieId)
        {
            var dbQuery = await Query()
                .Include(i => i.Organisatie)
                .Where(x => x.OrganisatieId == organisatieId && x.Status == HaarwerkStatus.Nieuw)
                .ToListAsync();

            return dbQuery;
        }

        public async Task<List<Haarwerk>> GetNietVerwerkteHaarwerken(Guid organisatieId, List<Guid> ids)
        {
            var dbQuery = await Query()
                .Include(i => i.Organisatie)
                .Where(x => ids.Contains(x.Id) && x.OrganisatieId == organisatieId && x.Status == HaarwerkStatus.Nieuw)
                .ToListAsync();

            return dbQuery;
        }
    }
}
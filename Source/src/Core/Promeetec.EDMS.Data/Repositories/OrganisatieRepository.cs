using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

namespace Promeetec.EDMS.Data.Repositories;

public class OrganisatieRepository : Repository<Organisatie>, IOrganisatieRepository
{
    public OrganisatieRepository(EDMSDbContext context)
        : base(context)
    {
    }

}
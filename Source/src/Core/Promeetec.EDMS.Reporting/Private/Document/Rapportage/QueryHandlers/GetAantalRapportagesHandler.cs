using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.QueryHandlers;

public class GetAantalRapportagesHandler : IQueryHandlerAsync<GetAantalRapportages, int>
{
    private readonly IRapportageRepository _repository;
    public GetAantalRapportagesHandler(IRapportageRepository dispatcher)
    {
        _repository = dispatcher;
    }

    public async Task<int> HandleAsync(GetAantalRapportages query)
    {
        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.OrganisatieId == query.OrganisatieId);

        // Filter de rapportages voor level 1 gebruikers. Zij mogen alleen eigen rapporages zien.
        if (query.User.IsInRole(RoleNames.RaadplegenEigenRapportages))
        {
            dbQuery = dbQuery.Where(x => x.EigenaarId == query.User.Id);
        }

        return await dbQuery.CountAsync();
    }
}
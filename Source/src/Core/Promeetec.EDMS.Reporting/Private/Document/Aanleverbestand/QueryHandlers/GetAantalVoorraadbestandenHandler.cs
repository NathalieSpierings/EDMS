using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.QueryHandlers;

public class GetAantalVoorraadbestandenHandler : IQueryHandlerAsync<GetAantalVoorraadbestanden, int>
{
    private readonly IAanleverbestandRepository _repository;
    public GetAantalVoorraadbestandenHandler(IAanleverbestandRepository dispatcher)
    {
        _repository = dispatcher;
    }

    public async Task<int> HandleAsync(GetAantalVoorraadbestanden query)
    {
        var dbQuery = _repository.Query().AsNoTracking();

        if (query.User.IsInRole(RoleNames.RaadplegenAanleverbestanden))
        {
            dbQuery = dbQuery.Where(x => x.WorkFlowState == AanleverbestandWorkflowState.Voorraad &&
                                         x.VoorraadId == query.VoorraadId &&
                                         x.Voorraad.Organisatie.Id == query.OrganisatieId);
        }
        else if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
        {
            dbQuery = dbQuery.Where(x => x.WorkFlowState == AanleverbestandWorkflowState.Voorraad &&
                                         x.VoorraadId == query.VoorraadId &&
                                         x.Voorraad.Organisatie.Id == query.OrganisatieId &&
                                         x.EigenaarId == query.User.Id);
        }

        return await dbQuery.CountAsync();
    }
}
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieSelectHandler : IQueryHandlerAsync<GetOrganisatieSelectViewModel, OrganisatieSelectViewModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetOrganisatieSelectHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganisatieSelectViewModel> HandleAsync(GetOrganisatieSelectViewModel query)
    {
        var dbQuery = await _repository.Query()
            .Where(x => x.Status != Status.Verwijderd)
            .ToListAsync();

        return new OrganisatieSelectViewModel
        {
            Organisaties = new SelectList(dbQuery, "Id", "Naam")
        };
    }
}
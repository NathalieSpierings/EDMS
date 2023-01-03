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

public class GetZorggroepRelatiesSelectListHandler : IQueryHandlerAsync<GetZorggroepRelatiesSelectList, ZorggroepRelatiesSelectViewModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetZorggroepRelatiesSelectListHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<ZorggroepRelatiesSelectViewModel> HandleAsync(GetZorggroepRelatiesSelectList query)
    {
        var dbQuery = await _repository.Query()
            .Where(x => x.Zorggroep && x.Status != Status.Verwijderd)
            .ToListAsync();

        return new ZorggroepRelatiesSelectViewModel
        {
            Zorggroepen = new SelectList(dbQuery, "Id", "Naam")
        };
    }
}
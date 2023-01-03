using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetGekoppeldeOrganisatiesHandler : IQueryHandler<GetGekoppeldeOrganisaties, GekoppeldeOrganisatiesModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetGekoppeldeOrganisatiesHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<GekoppeldeOrganisatiesModel> Handle(GetGekoppeldeOrganisaties query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.ZorggroepRelatieId == query.ZorggroepId && x.Status == Status.Actief);


        var model = new GekoppeldeOrganisatiesModel
        {
            GekoppeldeOrganisaties = dbQuery.Select(x => new OrganisatieModel
            {
                Id = x.Id,
                Nummer = x.Nummer,
                Naam = x.Naam,
            }).OrderBy(o => o.Naam)
        };

        return model;
    }
}
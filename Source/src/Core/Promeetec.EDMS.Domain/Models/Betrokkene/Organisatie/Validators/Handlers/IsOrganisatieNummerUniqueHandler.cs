using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Rules.Handlers;

public class IsOrganisatieNummerUniqueHandler : IQueryHandler<IsOrganisatieNummerUnique, bool>
{
    private readonly IOrganisatieRepository _repository;

    public IsOrganisatieNummerUniqueHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IsOrganisatieNummerUnique query)
    {
        bool any;
        if (query.Id != null)
        {
            any = await _repository.Query()
                .AnyAsync(x => x.Nummer == query.Nummer &&
                               x.Status != Status.Verwijderd &&
                               x.Id != query.Id);
        }
        else
        {
            any = await _repository.Query()
                .AnyAsync(x => x.Nummer == query.Nummer &&
                               x.Status != Status.Verwijderd);
        }

        return !any;
    }
}

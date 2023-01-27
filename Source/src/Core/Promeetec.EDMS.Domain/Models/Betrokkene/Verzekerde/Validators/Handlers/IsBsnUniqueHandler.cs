using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Queries;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators.Handlers;

public class IsBsnUniqueHandler : IQueryHandler<IsBsnUnique, bool>
{
    private readonly IVerzekerdeRepository _repository;

    public IsBsnUniqueHandler(IVerzekerdeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(IsBsnUnique query)
    {
        var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.AdresboekId == query.AdresboekId && x.Bsn == query.Bsn);
        return verzekerde == null || verzekerde.Status == Status.Verwijderd;
    }
}
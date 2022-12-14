using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Handlers;

public class IsGeboortedatumValidHandler : IQueryHandler<IsGeboortedatumValid, bool>
{

    public IsGeboortedatumValidHandler()
    {
    }

    public async Task<bool> Handle(IsGeboortedatumValid query)
    {
        await Task.CompletedTask;

        return query.Geboortedatum <= DateTime.Today;
    }
}
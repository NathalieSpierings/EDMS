using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Handlers;

public class IsStartdatumAfterIntakedatumHandler : IQueryHandler<IsStartdatumAfterIntakedatum, bool>
{

    public IsStartdatumAfterIntakedatumHandler()
    {
    }

    public async Task<bool> Handle(IsStartdatumAfterIntakedatum query)
    {
        await Task.CompletedTask;
        return query.Startdatum >= query.Intakedatum;
    }
}
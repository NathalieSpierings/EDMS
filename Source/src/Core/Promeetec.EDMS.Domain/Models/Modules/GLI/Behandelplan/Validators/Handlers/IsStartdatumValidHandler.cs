using System.Text.RegularExpressions;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Handlers;

public class IsStartdatumValidHandler : IQueryHandler<IsStartdatumValid, bool>
{

    public IsStartdatumValidHandler()
    {
    }

    public async Task<bool> Handle(IsStartdatumValid query)
    {
        await Task.CompletedTask;

        var regex = new Regex(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$");
        var match = regex.Match(query.Startdatum.ToString("dd-MM-yyyy"));
        return match.Success;
    }
}
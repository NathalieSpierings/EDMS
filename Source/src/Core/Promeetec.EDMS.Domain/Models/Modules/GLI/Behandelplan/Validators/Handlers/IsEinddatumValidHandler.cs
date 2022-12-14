using System.Text.RegularExpressions;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Handlers;

public class IsEinddatumValidHandler : IQueryHandler<IsEinddatumValid, bool>
{

    public IsEinddatumValidHandler()
    {
    }

    public async Task<bool> Handle(IsEinddatumValid query)
    {
        await Task.CompletedTask;

        var regex = new Regex(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$");
        var match = regex.Match(query.Einddatum.ToString("dd-MM-yyyy"));
        return match.Success;
    }
}
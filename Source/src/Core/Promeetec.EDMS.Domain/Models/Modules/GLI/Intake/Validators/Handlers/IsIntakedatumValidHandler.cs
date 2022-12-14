using System.Text.RegularExpressions;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators.Handlers;

public class IsIntakedatumValidHandler : IQueryHandler<IsIntakedatumValid, bool>
{

    public IsIntakedatumValidHandler()
    {
    }

    public async Task<bool> Handle(IsIntakedatumValid query)
    {
        await Task.CompletedTask;
        bool success = false;

        var regex = new Regex(@"^\d\d?[\-]\d\d?[\-]\d\d\d\d?\s*(?:\d{2}:\d{2}(?::\d{2})?)?$");
        var match = regex.Match(query.Intakedatum.ToString("dd-MM-yyyy"));
        if (match.Success)
        {
            success = query.Intakedatum <= DateTime.Today;
        }

        return success;
    }
}
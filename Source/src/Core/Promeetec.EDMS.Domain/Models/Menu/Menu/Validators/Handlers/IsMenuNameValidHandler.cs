using System.Text.RegularExpressions;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Handlers;

public class IsMenuNameValidHandler : IQueryHandler<IsMenuNameValid, bool>
{

    public IsMenuNameValidHandler()
    {
    }

    public async Task<bool> Handle(IsMenuNameValid query)
    {
        await Task.CompletedTask;

        if (string.IsNullOrWhiteSpace(query.Name)) 
            return false;

        var regex = new Regex(@"^[A-Za-z\d\s_-]+$");
        var match = regex.Match(query.Name);

        return match.Success;
    }
}
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Handlers;

public class IsBsnValidHandler : IQueryHandler<IsBsnValid, bool>
{

    public IsBsnValidHandler()
    {
    }

    public async Task<bool> Handle(IsBsnValid query)
    {
        await Task.CompletedTask;

        if (string.IsNullOrWhiteSpace(query.Bsn))
            return false;

        var bsn = query.Bsn;
        if (bsn.Length == 8)
            bsn = "0" + bsn;

        int.TryParse(bsn, out var bsnNummer);
        if (bsnNummer <= 9999999 || bsnNummer > 999999999)
            return false;

        int sum = -1 * bsnNummer % 10;

        for (int multiplier = 2; bsnNummer > 0; multiplier++)
        {
            int val = (bsnNummer /= 10) % 10;
            sum += multiplier * val;
        }

        return sum != 0 && sum % 11 == 0;
    }
}
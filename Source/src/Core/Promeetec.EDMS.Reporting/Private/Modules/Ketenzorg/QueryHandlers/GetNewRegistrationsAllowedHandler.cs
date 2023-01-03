using System;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetNewRegistrationsAllowedHandler : IQueryHandlerAsync<GetNewRegistrationsAllowed, bool>
{
    private readonly IDispatcher _dispatcher;

    public GetNewRegistrationsAllowedHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<bool> HandleAsync(GetNewRegistrationsAllowed query)
    {
        var machtiging = await _dispatcher.GetResultAsync(new GetMachtiging
        {
            MachtigingId = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer,
            IncludeRegistraties = true
        });

        if (machtiging != null)
        {
            return machtiging.Product.ActiviteitGroepen.Any(x => x.ResterendAantal > 0)
                   && (!machtiging.Einddatum.HasValue || DateTime.Today <= machtiging.Einddatum.Value.AddDays(+machtiging.MaxRegistrationRetroPeriodDays));
        }

        return false;
    }
}
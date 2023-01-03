using System;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetMachtigingRegistratieCreateHandler : IQueryHandlerAsync<GetMachtigingRegistratieCreate, MachtigingRegistratieCreateViewModel>
{
    private readonly IDispatcher _dispatcher;
    public GetMachtigingRegistratieCreateHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<MachtigingRegistratieCreateViewModel> HandleAsync(GetMachtigingRegistratieCreate query)
    {
        var machtiging = await _dispatcher.GetResultAsync(new GetMachtiging
        {
            MachtigingId = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer,
            IncludeRegistraties = true
        });

        var model = new MachtigingRegistratieCreateViewModel
        {
            Machtiging = machtiging,
            MachtigingStartDatum = machtiging.Startdatum,
            MachtigingEindDatum = machtiging.Einddatum,
            MaxRegistrationRetroPeriodDays = machtiging.MaxRegistrationRetroPeriodDays,
            Activiteiten = machtiging.Product.ActiviteitGroepen.SelectMany(x => x.Activiteiten).ToList(),
            NewRegistratiesAllowed = machtiging.Product.ActiviteitGroepen.Any(x => x.ResterendAantal > 0)
                                     && (!machtiging.Einddatum.HasValue || DateTime.Today <= machtiging.Einddatum.Value.AddDays(+machtiging.MaxRegistrationRetroPeriodDays))
        };

        return model;
    }
}
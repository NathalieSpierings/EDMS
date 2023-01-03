using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetSelectListMachtigingActiviteitenHandler : IQueryHandlerAsync<GetMachtigingActiviteitSelect, MachtigingActiviteitSelectViewModel>
{
    private readonly IDispatcher _dispatcher;
    public GetSelectListMachtigingActiviteitenHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<MachtigingActiviteitSelectViewModel> HandleAsync(GetMachtigingActiviteitSelect query)
    {
        var machtiging = await _dispatcher.GetResultAsync(new GetMachtiging
        {
            MachtigingId = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer,
            IncludeRegistraties = true
        });

        var activiteiten = machtiging.Product.ActiviteitGroepen.SelectMany(x => x.Activiteiten).ToList();

        return new MachtigingActiviteitSelectViewModel
        {
            Activiteiten = new SelectList(activiteiten, "Id", "Naam")
        };
    }
}
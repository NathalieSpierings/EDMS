using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetMachtigingRegistratieHandler : IQueryHandlerAsync<GetMachtigingRegistratie, MachtigingRegistratieViewModel>
{
    private readonly IDispatcher _dispatcher;

    public GetMachtigingRegistratieHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<MachtigingRegistratieViewModel> HandleAsync(GetMachtigingRegistratie query)
    {
        var machtiging = await _dispatcher.GetResultAsync(new GetMachtiging
        {
            MachtigingId = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer,
            IncludeRegistraties = true
        });

        var model = machtiging.Registraties.FirstOrDefault(x => x.Id == query.RegistratieId);

        return model;
    }
}
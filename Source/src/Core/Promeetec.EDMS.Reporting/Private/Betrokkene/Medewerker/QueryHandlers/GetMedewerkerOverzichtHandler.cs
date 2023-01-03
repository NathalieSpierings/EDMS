using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerOverzichtHandler : IQueryHandlerAsync<GetMedewerkerOverzicht, MedewerkerOverzichtViewModel>
{
    private readonly IDispatcher _dispatcher;

    public GetMedewerkerOverzichtHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<MedewerkerOverzichtViewModel> HandleAsync(GetMedewerkerOverzicht query)
    {
        var medewerker = await _dispatcher.GetResultAsync(new GetMedewerker
        {
            MedewerkerId = query.MedewerkerId,
            IncludeProfile = false,
            IncludeAvatar = false
        });

        if (medewerker == null)
            return new MedewerkerOverzichtViewModel();

        return new MedewerkerOverzichtViewModel
        {
            Medewerker = medewerker
        };
    }
}
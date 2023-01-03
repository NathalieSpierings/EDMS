using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Document.Overigbestand.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;

public class GetAanleveringOverigebestandenHandler : IQueryHandlerAsync<GetAanleveringOverigebestanden, AanleveringOverigebestandenViewModel>
{
    private readonly IDispatcher _dispatcher;

    public GetAanleveringOverigebestandenHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<AanleveringOverigebestandenViewModel> HandleAsync(GetAanleveringOverigebestanden query)
    {
        var model = new AanleveringOverigebestandenViewModel
        {
            Id = query.AanleveringId,
            Overigebestanden = await _dispatcher.GetResultAsync(new GetOverigbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId,
                IncludeDownloadActivities = true
            })
        };

        return model;
    }
}
using System.Threading.Tasks;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Document.Aanleverbestand.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.QueryHandlers;

public class GetAanleveringbestandenHandler : IQueryHandlerAsync<GetAanleveringAanleverbestanden, AanleveringAanleverbestandenViewModel>
{
    private readonly IDispatcher _dispatcher;

    public GetAanleveringbestandenHandler(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public async Task<AanleveringAanleverbestandenViewModel> HandleAsync(GetAanleveringAanleverbestanden query)
    {
        var model = new AanleveringAanleverbestandenViewModel
        {
            Id = query.AanleveringId,
            Aanleverbestanden = await _dispatcher.GetResultAsync(new GetAanleverbestanden
            {
                User = query.User,
                AanleveringId = query.AanleveringId
            })
        };

        return model;
    }
}
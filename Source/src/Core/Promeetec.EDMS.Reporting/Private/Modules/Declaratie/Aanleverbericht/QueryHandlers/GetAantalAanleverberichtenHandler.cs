using System;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.QueryHandlers;

public class GetAantalAanleverberichtenHandler : IQueryHandlerAsync<GetAantalAanleverberichten, int>
{
    private readonly IAanleverberichtRepository _repository;
    public GetAantalAanleverberichtenHandler(IAanleverberichtRepository dispatcher)
    {
        _repository = dispatcher;
    }

    public async Task<int> HandleAsync(GetAantalAanleverberichten query)
    {
        await Task.CompletedTask;

        var aantal = query.AanleveringId != null && query.AanleveringId != Guid.Empty
            ? _repository.GetAantalHoofdberichtenVanAanlevering(query.AanleveringId.Value)
            : _repository.GetAantalHoofdberichten();

        return aantal;
    }
}
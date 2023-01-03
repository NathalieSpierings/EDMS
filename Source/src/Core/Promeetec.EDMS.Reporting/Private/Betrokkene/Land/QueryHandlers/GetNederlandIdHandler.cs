using System;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.QueryHandlers;

public class GetNederlandIdHandler : IQueryHandler<GetNederlandId, Guid>
{
    private readonly ILandRepository _repository;
    public GetNederlandIdHandler(ILandRepository repository)
    {
        _repository = repository;
    }

    public Guid Handle(GetNederlandId query)
    {
        var id = _repository.GetNederlandId();
        return id;
    }
}
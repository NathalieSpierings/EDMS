using System.Linq;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Mededeling.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Mededeling.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Mededeling.Queryhandlers;

public class GetMededelingHandler : IQueryHandler<GetMededeling, MededelingViewModel>
{
    private readonly IMededelingRepository _repository;
    public GetMededelingHandler(IMededelingRepository repository)
    {
        _repository = repository;
    }

    public MededelingViewModel Handle(GetMededeling query)
    {
        var dbQuery = _repository.Query().FirstOrDefault();
        if (dbQuery == null)
            return new MededelingViewModel();

        return new MededelingViewModel
        {
            Id = dbQuery.Id,
            Content = dbQuery.Content
        };
    }
}
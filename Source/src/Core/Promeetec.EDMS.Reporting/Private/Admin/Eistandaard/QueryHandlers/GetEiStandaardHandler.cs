using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.QueryHandlers;

public class GetEiStandaardHandler : IQueryHandlerAsync<GetEiStandaard, EiStandaardViewModel>
{
    private readonly IEiStandaardRepository _repository;

    public GetEiStandaardHandler(IEiStandaardRepository repository)
    {
        _repository = repository;
    }


    public async Task<EiStandaardViewModel> HandleAsync(GetEiStandaard query)
    {
        var dbQuery = await _repository.Query().AsNoTracking()
            .Where(x => x.Id == query.EiStandaardId)
            .FirstOrDefaultAsync();

        if (dbQuery == null)
            return new EiStandaardViewModel();

        return new EiStandaardViewModel
        {
            Id = dbQuery.Id,
            Naam = dbQuery.Naam,
            EiBerichtCodes = dbQuery.EiBerichtCodes,
            Versie = dbQuery.Versie,
            SubVersie = dbQuery.SubVersie,
            Code = dbQuery.Code,
            Omschrijving = dbQuery.Omschrijving
        };
    }
}
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.Eistandaard.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.QueryHandlers;

public class GetEiStandaardenHandler : IQueryHandlerAsync<GetEiStandaarden, EiStandaardenViewModel>
{
    private readonly IEiStandaardRepository _repository;

    public GetEiStandaardenHandler(IEiStandaardRepository repository)
    {
        _repository = repository;
    }

    public async Task<EiStandaardenViewModel> HandleAsync(GetEiStandaarden query)
    {
        var model = new EiStandaardenViewModel();

        var dbQuery = _repository.Query().AsNoTracking();


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Naam.Contains(match) ||
                                             x.EiBerichtCodes.Contains(match) ||
                                             x.Versie.ToString().Contains(match) ||
                                             x.SubVersie.ToString().Contains(match) ||
                                             x.Code.Contains(match) ||
                                             x.Omschrijving.Contains(match));
            }
        }

        model.EiStandaarden = await dbQuery.Select(x => new EiStandaardViewModel
        {
            Id = x.Id,
            Naam = x.Naam,
            EiBerichtCodes = x.EiBerichtCodes,
            Versie = x.Versie,
            SubVersie = x.SubVersie,
            Code = x.Code,
            Omschrijving = x.Omschrijving
        }).ToListAsync();

        return model;
    }
}
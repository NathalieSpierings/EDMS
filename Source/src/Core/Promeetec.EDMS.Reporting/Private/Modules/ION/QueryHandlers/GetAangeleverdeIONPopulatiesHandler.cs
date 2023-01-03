using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Models;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.QueryHandlers;

public class GetAangeleverdeIONPopulatiesHandler : IQueryHandlerAsync<GetAangeleverdeIONPopulaties, AangeleverdeIONPopulatiesViewModel>
{
    private readonly IIONPopulatieRepository _repository;

    public GetAangeleverdeIONPopulatiesHandler(IIONPopulatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<AangeleverdeIONPopulatiesViewModel> HandleAsync(GetAangeleverdeIONPopulaties query)
    {
        await Task.CompletedTask;

        IEnumerable<IONPopulatieDto> records = new List<IONPopulatieDto>();
        if (query.Zorggroep)
        {
            records = _repository.GetZorggroepPopulatie(query.OrganisatieId);
        }
        else
        {
            records = _repository.GetOrganisatiePopulatie(query.User.IsInterneMedewerker, query.OrganisatieId, query.User.Id);
        }

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var peilDatum))
                {
                    records = records.Where(x => DbFunctions.TruncateTime(x.Periode) == peilDatum);
                }
                else if (DateTime.TryParse(match, out var aangeleverdOp))
                {
                    records = records.Where(x => DbFunctions.TruncateTime(x.AangeleverdOp) == aangeleverdOp);
                }
                else
                {
                    records = records.Where(x => x.AgbCodeZorgverlener.Contains(match) ||
                                                 x.AgbCodeOnderneming.Contains(match) ||
                                                 x.RaadplegerNaam.Contains(match));
                }
            }
        }


        var model = new AangeleverdeIONPopulatiesViewModel
        {
            OrganisatieId = query.OrganisatieId,
            Populaties = records,
        };


        return model;
    }
}
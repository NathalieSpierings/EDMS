using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.QueryHandlers;

/// <summary>
/// Deze query haalt een enkele rapportage op.
/// </summary>
public class GetRapportageHandler : IQueryHandlerAsync<GetRapportage, RapportageViewModel>
{
    private readonly IRapportageRepository _repository;

    public GetRapportageHandler(IRapportageRepository repository)
    {
        _repository = repository;
    }

    public async Task<RapportageViewModel> HandleAsync(GetRapportage query)
    {
        RapportageViewModel model;
        var dbQuery = _repository.Query().AsNoTracking().Where(x => x.Id == query.RappoortageId);

        if (query.IncludeData)
        {
            model = await dbQuery.Select(x => new RapportageViewModel
            {
                Id = x.Id,
                Referentie = x.Referentie,
                RapportageSoort = x.RapportageSoort,
                FileName = x.FileName,
                FileSize = x.FileSize,
                Extension = x.Extension,
                MimeType = x.MimeType,
                Data = x.Data,
                AangemaaktOp = x.AangemaaktOp,
                EigenaarId = x.EigenaarId,
                EigenaarNaam = x.Eigenaar.Persoon.VolledigeNaam,
                OrganisatieId = x.OrganisatieId,
                OrganisatieNaam = x.Organisatie.Naam,
            }).FirstOrDefaultAsync();
        }
        else
        {
            model = await dbQuery.Select(x => new RapportageViewModel
            {
                Id = x.Id,
                Referentie = x.Referentie,
                RapportageSoort = x.RapportageSoort,
                FileName = x.FileName,
                FileSize = x.FileSize,
                Extension = x.Extension,
                AangemaaktOp = x.AangemaaktOp,
                EigenaarId = x.EigenaarId,
                EigenaarNaam = x.Eigenaar.Persoon.VolledigeNaam,
                OrganisatieId = x.OrganisatieId,
                OrganisatieNaam = x.Organisatie.Naam,
            }).FirstOrDefaultAsync();
        }

        return model;
    }
}
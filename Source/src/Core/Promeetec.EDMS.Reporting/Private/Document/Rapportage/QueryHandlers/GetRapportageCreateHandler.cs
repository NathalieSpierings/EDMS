using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.QueryHandlers;

public class GetRapportageCreateHandler : IQueryHandlerAsync<GetRapportageCreate, RapportageCreateViewModel>
{
    private readonly IRapportageRepository _repository;

    public GetRapportageCreateHandler(IRapportageRepository repository)
    {
        _repository = repository;
    }

    public async Task<RapportageCreateViewModel> HandleAsync(GetRapportageCreate query)
    {
        var dbQuery = await _repository.Query()
            .FirstOrDefaultAsync(x => x.Id == query.RapportageId && x.OrganisatieId == query.OrganisatieId);


        var model = await _repository.Query()
            .AsNoTracking()
            .Where(x => x.Id == query.RapportageId && x.OrganisatieId == query.OrganisatieId)
            .Select(x => new RapportageCreateViewModel
            {
                Id = x.Id,
                ReferentiePromeetec = x.Referentie,
                RapportageSoort = x.RapportageSoort,
                FileName = x.FileName,
                FileSize = x.FileSize,
                AangemaaktOp = x.AangemaaktOp,
                EigenaarId = x.EigenaarId,
                Organisatie = new OrganisatieViewModel
                {
                    Id = x.OrganisatieId,
                    Nummer = x.Organisatie.Nummer,
                    Naam = x.Organisatie.Naam,
                }
            }).FirstOrDefaultAsync();

        return model;
    }
}
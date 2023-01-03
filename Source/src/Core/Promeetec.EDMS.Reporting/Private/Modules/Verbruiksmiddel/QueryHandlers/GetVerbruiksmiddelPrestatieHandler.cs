using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Queries;
using Promeetec.EDMS.Reporting.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.QueryHandlers;

public class GetVerbruiksmiddelPrestatieHandler : IQueryHandlerAsync<GetVerbruiksmiddelPrestatie, VerbruiksmiddelPrestatieViewModel>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;
    private readonly IDispatcher _dispatcher;
    public GetVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository, IDispatcher dispatcher)
    {
        _repository = repository;
        _dispatcher = dispatcher;
    }

    public async Task<VerbruiksmiddelPrestatieViewModel> HandleAsync(GetVerbruiksmiddelPrestatie query)
    {
        var dbQuery = await _repository
            .Query()
            .Where(x => x.Id == query.VerbruiksmiddelPrestatieId)
            .FirstOrDefaultAsync();

        if (dbQuery == null)
            return new VerbruiksmiddelPrestatieViewModel();

        var model = new VerbruiksmiddelPrestatieViewModel
        {
            Id = dbQuery.Id,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            HulpmiddelenSoort = dbQuery.HulpmiddelenSoort,
            Status = dbQuery.Status,
            AangemaaktDoor = dbQuery.AangemaaktDoor,
            AangemaaktDoorId = dbQuery.AangemaaktDoorId,
            AangemaaktOp = dbQuery.AangemaaktOp,
            Zorgprofiel = new ZorgprofielViewModel
            {
                ProfielCode = dbQuery.ProfielCode,
                ProfielStartdatum = dbQuery.ProfielStartdatum,
                ProfielEinddatum = dbQuery.ProfielEinddatum ?? dbQuery.ProfielEinddatum
            },
            Hulpmiddel = new VerbruiksmiddelHulpmiddelViewModel
            {
                ZIndex = dbQuery.ZIndex,
                PrestatieDatum = dbQuery.PrestatieDatum,
                Hoeveelheid = dbQuery.Hoeveelheid,
            },
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.OrganisatieId,
                Nummer = dbQuery.Organisatie?.Nummer,
                Naam = dbQuery.Organisatie?.Naam
            },
            Verzekerde = new VerzekerdeViewModel
            {
                Id = dbQuery.VerzekerdeId
            }
        };

        model.Verzekerde = await _dispatcher.GetResultAsync(new GetVerzekerde
        {
            VerzekerdeId = model.Verzekerde.Id
        });

        return model;
    }
}
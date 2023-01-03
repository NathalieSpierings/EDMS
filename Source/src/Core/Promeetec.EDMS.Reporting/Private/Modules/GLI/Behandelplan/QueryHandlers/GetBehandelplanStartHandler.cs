using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.QueryHandlers;

public class GetBehandelplanStartHandler : IQueryHandlerAsync<GetBehandelplanStart, StartBehandelplanViewModel>
{
    private readonly IGliIntakeRepository _intakeRepository;

    public GetBehandelplanStartHandler(IGliIntakeRepository intakeRepository)
    {
        _intakeRepository = intakeRepository;
    }

    public async Task<StartBehandelplanViewModel> HandleAsync(GetBehandelplanStart query)
    {
        var model = await _intakeRepository.Query()
            .AsNoTracking()
            .Where(x => x.Id == query.IntakeId && x.OrganisatieId == query.OrganisatieId)
            .Select(x => new StartBehandelplanViewModel
            {
                OrganisatieId = query.OrganisatieId,
                IntakeId = query.IntakeId,
                Intakedatum = x.IntakeDatum,
                Fase = GliBehandelfase.Behandelfase1,
                Behandelaar = new MedewerkerViewModel
                {
                    Id = x.BehandelaarId,
                    VolledigeNaam = x.Behandelaar.Persoon.VolledigeNaam
                },
                Verzekerde = new VerzekerdeViewModel
                {
                    Id = x.VerzekerdeId,
                    AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
                    NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
                    Lengte = x.Verzekerde.Lengte,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                    },
                    FormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
                    VolledigeNaam = x.Verzekerde.Persoon.VolledigeNaam,
                    Achternaam = x.Verzekerde.Persoon.Achternaam,
                }
            }).FirstOrDefaultAsync();

        return model;
    }
}
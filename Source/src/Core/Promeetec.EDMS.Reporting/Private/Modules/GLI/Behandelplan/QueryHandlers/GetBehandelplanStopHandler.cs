using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.RedenEindeZorg.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.QueryHandlers;

public class GetBehandelplanStopHandler : IQueryHandlerAsync<GetBehandelplanStop, StopBehandelplanViewModel>
{
    private readonly IGliBehandelplanRepository _repository;

    public GetBehandelplanStopHandler(IGliBehandelplanRepository repository)
    {
        _repository = repository;
    }

    public async Task<StopBehandelplanViewModel> HandleAsync(GetBehandelplanStop query)
    {
        var model = await _repository.Query().AsNoTracking()
            .Where(x => x.IntakeId == query.IntakeId
                        && x.OrganisatieId == query.OrganisatieId
                        && x.GliStatus == GliStatus.Gestart)
            .Select(x => new StopBehandelplanViewModel
            {
                Id = x.Id,
                OrganisatieId = query.OrganisatieId,
                IntakeId = x.IntakeId,
                Intakedatum = x.Intake.IntakeDatum,
                Startdatum = x.Startdatum,
                VoortijdigeStopdatum = x.VoortijdigeStopdatum ?? DateTime.MinValue,
                VoortijdigGestopt = x.VoortijdigGestopt,
                GliProgramma = x.GliProgramma,
                Opmerking = x.Opmerking,
                GliStatus = x.GliStatus,
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
                },
                RedenEindeZorg = new RedenEindeZorgViewModel
                {
                    Id = x.RedenEindeZorgId ?? Guid.Empty,
                    Code = x.RedenEindeZorg.Code,
                    Omschrijving = x.RedenEindeZorg.Omschrijving
                }
            }).FirstOrDefaultAsync();

        return model;
    }
}
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.WeegMoment.Models;
using Promeetec.EDMS.Reporting.Modules.GLI.Behandelplan.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.QueryHandlers;

public class GetIntakeHandler : IQueryHandlerAsync<GetGliIntake, GliIntakeViewModel>
{
    private readonly IGliIntakeRepository _repository;

    public GetIntakeHandler(IGliIntakeRepository repository)
    {
        _repository = repository;
    }

    public async Task<GliIntakeViewModel> HandleAsync(GetGliIntake query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.WeegMomenten)
            .Include(i => i.Behandelaar)
            .Include(i => i.Behandelplannen)
            .Where(x => x.Id == query.IntakeId);

        var model = await dbQuery.Select(x => new GliIntakeViewModel
        {
            Id = x.Id,
            Organisatie = new OrganisatieViewModel
            {
                Id = x.OrganisatieId,
                Nummer = x.Organisatie.Nummer,
                Naam = x.Organisatie.Naam
            },
            VerzekerdeId = x.VerzekerdeId,
            Bsn = x.Verzekerde.Bsn,
            AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
            NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
            Lengte = x.Verzekerde.Lengte,
            Client = x.Verzekerde.Persoon.VolledigeNaam,
            WeegMomenten = x.Verzekerde.WeegMomenten.Select(y => new WeegMomentViewModel
            {
                Id = y.Id,
                VerzekerdeId = y.VerzekerdeId.Value,
                Lengte = x.Verzekerde.Lengte,
                Gewicht = y.Gewicht,
                Opnamedatum = y.Opnamedatum
            }),
            IntakeDatum = x.IntakeDatum,
            Opmerking = x.Opmerking,
            Status = x.GliStatus,
            BehandelaarId = x.BehandelaarId,
            Behandelaar = x.Behandelaar.Persoon.VolledigeNaam,
            Verwerkt = x.Verwerkt,
            VerwerktOp = x.VerwerktOp,
            Behandelplannen = x.Behandelplannen.Select(b => new BehandelplanViewModel
            {
                Id = b.Id,
                Startdatum = b.Startdatum,
                Einddatum = b.Einddatum,
                GliProgramma = b.GliProgramma,
                Fase = b.Fase,
                Status = b.GliStatus,
                Opmerking = b.Opmerking,
                VoortijdigGestopt = b.VoortijdigGestopt,
                VoortijdigeStopdatum = b.VoortijdigeStopdatum,
                Verwerkt = b.Verwerkt,
                VerwerktOp = b.VerwerktOp
            })
        }).FirstOrDefaultAsync();

        return model;
    }
}
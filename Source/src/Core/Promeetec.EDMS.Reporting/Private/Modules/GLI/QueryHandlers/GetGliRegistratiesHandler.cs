using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.QueryHandlers;

public class GetBehandelplannenHandler : IQueryHandlerAsync<GetGliRegistraties, GliRegistratiesViewModel>
{
    private readonly IGliIntakeRepository _repository;

    public GetBehandelplannenHandler(IGliIntakeRepository repository)
    {
        _repository = repository;
    }

    public async Task<GliRegistratiesViewModel> HandleAsync(GetGliRegistraties query)
    {
        await Task.CompletedTask;

        var model = new GliRegistratiesViewModel
        {
            OrganisatieId = query.OrganisatieId,
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Verzekerde)
            .Where(x => x.OrganisatieId == query.OrganisatieId);

        if (query.User.IsInRole(RoleNames.RaadplegenGliRegistraties))
        {
            // Alle registraties mogen getoond worden
        }
        else if (query.User.IsInRole(RoleNames.RaadplegenEigenGliRegistraties))
        {
            // Alleen registraties van de eigenaar mogen getoond worden
            dbQuery = dbQuery.Where(x => x.BehandelaarId == query.User.Id);
        }


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var intakeDatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.IntakeDatum) == intakeDatum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Verzekerde.Persoon.FormeleNaam.Contains(match)
                                                 || x.Verzekerde.AgbCodeVerwijzer.Contains(match)
                                                 || x.Verzekerde.NaamVerwijzer.Contains(match)
                                                 || x.Verzekerde.Bsn.Contains(match));
                }
            }
        }

        model.GliRegistraties = dbQuery.Select(x => new GliRegistratieListItemViewModel
        {
            Id = x.Id,
            OrganisatieId = x.OrganisatieId,
            VerzekerdeId = x.VerzekerdeId,
            VerzekerdeFormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
            VerzekerdeLengte = x.Verzekerde.Lengte,
            Bsn = x.Verzekerde.Bsn,
            Geboortedatum = x.Verzekerde.Persoon.Geboortedatum,
            IntakeDatum = x.IntakeDatum,
            Verwerkt = x.Verwerkt,
            VerwerktOp = x.VerwerktOp,
            GliStatus = x.GliStatus,
            IsFase1Gestart = x.Behandelplannen.FirstOrDefault(y => y.Fase == GliBehandelfase.Behandelfase1).GliStatus == GliStatus.Gestart
        });


        return model;
    }
}
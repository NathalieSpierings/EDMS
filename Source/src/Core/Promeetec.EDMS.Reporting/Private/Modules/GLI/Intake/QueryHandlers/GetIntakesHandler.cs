using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.QueryHandlers;

public class GetIntakesHandler : IQueryHandlerAsync<GetIntakes, IntakesViewModel>
{
    private readonly IGliIntakeRepository _repository;

    public GetIntakesHandler(IGliIntakeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IntakesViewModel> HandleAsync(GetIntakes query)
    {
        await Task.CompletedTask;

        var model = new IntakesViewModel
        {
            OrganisatieId = query.OrganisatieId
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

        model.Intakes = dbQuery.Select(x => new GliIntakeListItemViewModel
        {
            Id = x.Id,
            OrganisatieId = x.OrganisatieId,
            VerzekerdeId = x.VerzekerdeId,
            IntakeDatum = x.IntakeDatum,
            VerzekerdeFormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
            Bsn = x.Verzekerde.Bsn,
            AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
            NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
            Verwerkt = x.Verwerkt,
            VerwerktOp = x.VerwerktOp,
            BehandeltrajectGestart = x.Behandelplannen.Count > 0
        }).OrderBy(o => o.IntakeDatum);


        return model;
    }
}
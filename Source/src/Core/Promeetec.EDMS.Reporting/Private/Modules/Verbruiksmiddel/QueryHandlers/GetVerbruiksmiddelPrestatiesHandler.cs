using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.QueryHandlers;

public class GetVerbruiksmiddelPrestatiesHandler : IQueryHandlerAsync<GetVerbruiksmiddelPrestaties, VerbruiksmiddelPrestatiesViewModel>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;

    public GetVerbruiksmiddelPrestatiesHandler(IVerbruiksmiddelPrestatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerbruiksmiddelPrestatiesViewModel> HandleAsync(GetVerbruiksmiddelPrestaties query)
    {
        await Task.CompletedTask;

        var model = new VerbruiksmiddelPrestatiesViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam
        };

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.Zorgverzekering)
            .Include(i => i.Verzekerde.Zorgverzekering.Verzekeraar)
            .Where(x => x.OrganisatieId == query.OrganisatieId);

        dbQuery = query.Processed
            ? dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId && x.Status == VerbruiksmiddelPrestatieStatus.Verwerkt)
            : dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId && x.Status == VerbruiksmiddelPrestatieStatus.Nieuw);


        if (query.User.IsInRole(RoleNames.RaadplegenVerbruiksmiddelPrestaties))
        {
            // Alle prestaties mogen getoond worden
        }
        else if (query.User.IsInRole(RoleNames.RaadplegenEigenVerbruiksmiddelPrestaties))
        {
            // Alleen prestaties van deze agbcodeonderneming mogen getoond worden
            var praktijkCodes = query.User.AgbCodeOnderneming.Split(',').ToList();
            var praktijk = praktijkCodes.FirstOrDefault();

            dbQuery = dbQuery.Where(x => x.AgbCodeOnderneming == praktijk);
        }


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var startDatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.ProfielStartdatum) == startDatum);
                }
                else if (DateTime.TryParse(match, out var einddatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.ProfielEinddatum) == einddatum);
                }
                else if (DateTime.TryParse(match, out var prestatieDatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.PrestatieDatum) == prestatieDatum);
                }
                else if (DateTime.TryParse(match, out var geboortedatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.Verzekerde.Persoon.Geboortedatum) == geboortedatum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Verzekerde.Persoon.FormeleNaam.Contains(match) ||
                                                 x.Verzekerde.Zorgprofiel.ProfielCode.ToString().Contains(match) ||
                                                 x.ZIndex.ToString().Contains(match) ||
                                                 x.HulpmiddelenSoort.ToString().Contains(match) ||
                                                 x.Status.ToString().Contains(match));
                }
            }
        }


        model.Prestaties = dbQuery.Select(x => new VerbruiksmiddelPrestatieListItemViewModel
        {
            Id = x.Id,
            OrganisatieId = x.OrganisatieId,
            VerzekerdeId = x.VerzekerdeId,
            VerzekerdeFormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
            Geboortedatum = x.Verzekerde.Persoon.Geboortedatum,
            ProfielCode = x.ProfielCode,
            ProfielStartdatum = x.ProfielStartdatum,
            ProfielEinddatum = x.ProfielEinddatum,
            ZIndex = x.ZIndex,
            PrestatieStartdatum = x.PrestatieDatum,
            Status = x.Status,
            HulpmiddelenSoort = x.HulpmiddelenSoort
        });

        return model;
    }
}
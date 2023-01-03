using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.QueryHandlers;


public class GetRapportagesHandler : IQueryHandlerAsync<GetRapportages, RapportagesViewModel>
{
    private readonly IRapportageRepository _repository;

    public GetRapportagesHandler(IRapportageRepository repository)
    {
        _repository = repository;
    }

    public async Task<RapportagesViewModel> HandleAsync(GetRapportages query)
    {
        await Task.CompletedTask;

        var model = new RapportagesViewModel
        {
            OrganisatieId = query.OrganisatieId ?? Guid.Empty,
            OrganisatieNaam = query.OrganisatieNaam,
            Rapportages = new List<RapportageListItemViewModel>()
        };

        var dbQuery = _repository.Query().AsNoTracking();


        // We halen de rapportages op van de gegeven organisatie
        if (query.OrganisatieId != null && query.OrganisatieId != Guid.Empty)
        {
            dbQuery = dbQuery.Where(x => x.OrganisatieId == query.OrganisatieId);

            // Filter de rapportages voor level 1 gebruikers. Zij mogen alleen eigen rapporages zien.
            if (query.User.IsInRole(RoleNames.RaadplegenEigenRapportages))
            {
                dbQuery = dbQuery.Where(x => x.EigenaarId == query.User.Id);
            }
        }
        else if (query.BehandelaarId != Guid.Empty && query.BehandelaarId.HasValue)
        {
            // Alle rapportages van alle organisaties aangemaakt door gegeven DS medewerker.
            dbQuery = dbQuery.Where(x => x.AangemaaktDoor == query.BehandelaarId.Value);
        }

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var datum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.AangemaaktOp) == datum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Referentie.Contains(match) ||
                                                 x.FileName.Contains(match) ||
                                                 x.Eigenaar.Persoon.FormeleNaam.Contains(match) ||
                                                 x.Organisatie.Nummer.Contains(match) ||
                                                 x.Organisatie.Naam.Contains(match));
                }
            }
        }


        model.Rapportages = await dbQuery.Select(x => new RapportageListItemViewModel
        {
            Id = x.Id,
            Referentie = x.Referentie,
            RapportageSoort = x.RapportageSoort,
            FileName = x.FileName,
            FileSize = x.FileSize,
            Extension = x.Extension,
            AangemaaktOp = x.AangemaaktOp,
            EigenaarId = x.EigenaarId,
            EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
            BehandelaarId = x.AangemaaktDoor.Value,
            BehandelaarNaam = x.AangemaaktDoorNaam,
            OrganisatieId = x.OrganisatieId,
            OrganisatieNaam = x.Organisatie.Naam
        }).OrderBy(o => o.AangemaaktOp).ToListAsync();

        return model;
    }
}
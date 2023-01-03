using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.DownloadActivity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.DownloadActivity.Models;
using Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;
using Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.QueryHandlers;

public class GetDownloadActivitiesHandler : IQueryHandlerAsync<GetDownloadActivities, DownloadActivitiesViewModel>
{
    private readonly IDownloadActivityRepository _repository;
    public GetDownloadActivitiesHandler(IDownloadActivityRepository repository)
    {
        _repository = repository;
    }


    public async Task<DownloadActivitiesViewModel> HandleAsync(GetDownloadActivities query)
    {
        await Task.CompletedTask;

        var model = new DownloadActivitiesViewModel();

        var dbQuery = _repository.Query()
            .AsNoTracking();

        if (query.BestandId != null && query.BestandId != Guid.Empty)
        {
            dbQuery = dbQuery.Where(x => x.BestandId == query.BestandId);
        }
        else if (query.MedewerkerId != null && query.MedewerkerId != Guid.Empty)
        {
            dbQuery = dbQuery.Where(x => x.MedewerkerId == query.MedewerkerId);
        }


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var downloadDatum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.GedownloadOp) == downloadDatum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.BestandSoort.ToString().Contains(match) ||
                                                 x.Bestand.FileName.Contains(match) ||
                                                 x.Medewerker.Persoon.FormeleNaam.Contains(match));
                }
            }
        }

        model.Downloads = dbQuery.Select(x => new DownloadActivityListItemViewModel
        {
            Id = x.Id,
            GedownloadOp = x.GedownloadOp,
            BestandSoort = x.BestandSoort,
            DownloaderId = x.MedewerkerId,
            DownloaderFormeleNaam = x.Medewerker.Persoon.FormeleNaam,
            Bestandsnaam = x.Bestand.FileName,
            BestandId = x.Bestand.Id,
            VoorraadId = x.VoorraadId,
            AanleveringId = x.AanleveringId,
            OrganisatieId = x.Bestand.Eigenaar.OrganisatieId
        }).OrderBy(o => o.GedownloadOp);

        return model;
    }
}
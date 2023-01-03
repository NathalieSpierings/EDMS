using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.DownloadActivity.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.QueryHandlers;

public class GetOverigebestandenHandler : IQueryHandlerAsync<GetOverigbestanden, OverigbestandenViewModel>
{
    private readonly IOverigbestandRepository _repository;
    private readonly IDispatcher _dispatcher;

    public GetOverigebestandenHandler(IOverigbestandRepository repository, IDispatcher dispatcher)
    {
        _repository = repository;
        _dispatcher = dispatcher;
    }

    public async Task<OverigbestandenViewModel> HandleAsync(GetOverigbestanden query)
    {
        await Task.CompletedTask;

        var model = new OverigbestandenViewModel
        {
            AanleveringId = query.AanleveringId,
            Overigbestanden = new List<OverigbestandListItemViewModel>()
        };

        if (query.User.IsInRole(RoleNames.RaadplegenAanleverbestanden))
        {
            var dbQuery = _repository
                .Query()
                .AsNoTracking()
                .Where(x => x.AanleveringId == query.AanleveringId)
                .Select(x => new OverigbestandListItemViewModel
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    Extension = x.Extension,
                    AangemaaktOp = x.AangemaaktOp,
                    AangemaaktDoor = x.AangemaaktDoor,
                    EigenaarId = x.EigenaarId,
                    EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
                    EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                    EigenaarAgbCode = x.Eigenaar.AgbCodeZorgverlener,
                    OrganisatieId = x.Eigenaar.OrganisatieId,
                    OrganisatieNummer = x.Eigenaar.Organisatie.Nummer,
                    AangemaaktDoorNaam = x.AangemaaktDoorNaam
                }).OrderBy(o => o.AangemaaktOp);

            model.Overigbestanden = dbQuery;

            if (query.IncludeDownloadActivities)
            {
                model.DownloadActivities = await _dispatcher.GetResultAsync(new GetDownloadActivities
                {
                    MedewerkerId = query.User.Id
                });
            }

            return model;
        }

        if (query.User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
        {
            var dbQuery = _repository
                .Query()
                .AsNoTracking()
                .Where(x => x.AanleveringId == query.AanleveringId && x.EigenaarId == query.User.Id)
                .Select(x => new OverigbestandListItemViewModel
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    Extension = x.Extension,
                    AangemaaktOp = x.AangemaaktOp,
                    AangemaaktDoor = x.AangemaaktDoor,
                    EigenaarId = x.EigenaarId,
                    EigenaarFormeleNaam = x.Eigenaar.Persoon.FormeleNaam,
                    EigenaarVolledigeNaam = x.Eigenaar.Persoon.VolledigeNaam,
                    EigenaarAgbCode = x.Eigenaar.AgbCodeZorgverlener,
                    OrganisatieId = x.Eigenaar.OrganisatieId,
                    OrganisatieNummer = x.Eigenaar.Organisatie.Nummer,
                    AangemaaktDoorNaam = x.AangemaaktDoorNaam
                }).OrderBy(o => o.AangemaaktOp);

            // var overigebestanden = dbQuery.OrderBy(o => o.AangemaaktOp).ToList();

            model.Overigbestanden = dbQuery;

            if (query.IncludeDownloadActivities)
            {
                model.DownloadActivities = await _dispatcher.GetResultAsync(new GetDownloadActivities
                {
                    MedewerkerId = query.User.Id
                });
            }

            return model;
        }

        return model;
    }
}
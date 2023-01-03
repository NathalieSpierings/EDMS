using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Models;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.QueryHandlers;

public class GetRapportageDashboardWidgetHandler : IQueryHandlerAsync<GetRapportageDashboardWidget, RapportageDashboardWidgetViewModel>
{
    private readonly IRapportageRepository _repository;

    public GetRapportageDashboardWidgetHandler(IRapportageRepository repository)
    {
        _repository = repository;
    }

    public async Task<RapportageDashboardWidgetViewModel> HandleAsync(GetRapportageDashboardWidget query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.OrganisatieId == query.OrganisatieId);

        // Filter de rapportages voor level 1 gebruikers. Zij mogen alleen eigen rapporages zien.
        if (query.User.IsInRole(RoleNames.RaadplegenEigenRapportages))
        {
            dbQuery = dbQuery.Where(x => x.EigenaarId == query.User.Id);
        }

        if (query.StartDatum != DateTime.MinValue)
            dbQuery = dbQuery.Where(x => x.AangemaaktOp >= query.StartDatum);

        if (query.EindDatum != DateTime.MinValue)
            dbQuery = dbQuery.Where(x => x.AangemaaktOp <= query.EindDatum);

        var rapportages = dbQuery.SelectPage(x => x.AangemaaktOp, false, query.PageIndex, query.PageSize).ToList();

        var model = new RapportageDashboardWidgetViewModel
        {
            Rapportages = rapportages
        };

        return model;
    }
}
using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Queries;

public class GetRapportageDashboardWidget : IQuery<RapportageDashboardWidgetViewModel>
{
    public Guid OrganisatieId { get; set; }
    public DateTime? StartDatum { get; set; }
    public DateTime? EindDatum { get; set; }
    public UserPrincipal User { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
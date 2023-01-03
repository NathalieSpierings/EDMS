using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetOrganisatieDashboard : IQuery<OrganisatieDashboardViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid VoorraadId { get; set; }
    public Guid AdresboekId { get; set; }
    public DateTime? StartDatum { get; set; }
    public DateTime? EindDatum { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public UserPrincipal User { get; set; }
}
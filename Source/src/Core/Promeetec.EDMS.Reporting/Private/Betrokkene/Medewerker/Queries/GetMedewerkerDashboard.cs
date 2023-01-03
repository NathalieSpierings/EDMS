using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerDashboard : IQuery<MedewerkerDashboardViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid MedewerkerId { get; set; }
    public DateTime? StartDatum { get; set; }
    public DateTime? EindDatum { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public UserPrincipal User { get; set; }
}
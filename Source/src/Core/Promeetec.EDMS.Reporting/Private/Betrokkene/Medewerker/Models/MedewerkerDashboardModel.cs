using System;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Dashboard.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Dashboard.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerDashboardViewModel : ModelBase
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
    public bool ShowDeclaratieDashboard { get; set; }
    public bool ShowVerbruiksmiddelenDashboard { get; set; }
    public MedewerkerViewModel Medewerker { get; set; }
    public DeclaratieDashboardViewModel DeclaratieDashboard { get; set; }
    public VerbruiksmiddelenDashboardViewModel VerbruiksmiddelenDashboard { get; set; }
}
using System;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Dashboard.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Dashboard.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieDashboardViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public Guid VoorraadId { get; set; }
    public Guid AdresboekId { get; set; }


    public bool ShowDeclaratieDashboard { get; set; }
    public bool ShowVerbruiksmiddelenDashboard { get; set; }
    public bool ShowMachtigingenDashboard { get; set; }

    public DeclaratieDashboardViewModel DeclaratieDashboard { get; set; }
    public VerbruiksmiddelenDashboardViewModel VerbruiksmiddelenDashboard { get; set; }
}
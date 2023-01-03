using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Dashboard.Models;

public class VerbruiksmiddelenDashboardViewModel : ModelBase
{
    public int AantalNieuwePrestaties { get; set; }
    public int AantalVerwerktePrestaties { get; set; }

    // Rapportages lijst
    public RapportageDashboardWidgetViewModel Rapportages { get; set; }
}
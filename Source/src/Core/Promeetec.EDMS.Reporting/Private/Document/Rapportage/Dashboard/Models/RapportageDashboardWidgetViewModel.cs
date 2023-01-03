using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Models;

public class RapportageDashboardWidgetViewModel : ModelBase
{
    public List<Domain.Models.Document.Rapportage.Rapportage> Rapportages { get; set; } = new();
    public int AantalRapportages => Rapportages?.Count ?? 0;
}
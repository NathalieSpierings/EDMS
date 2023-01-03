using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Dashboard.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Dashboard.Models;

public class DeclaratieDashboardViewModel : ModelBase
{
    // Stats
    public int AantalActiveAanleveringen { get; set; }
    public int AantalAfgehandeldeAanleveringen { get; set; }
    public int AantalVoorraadbestanden { get; set; }
    public int AantalAanleveringen { get; set; }

    public GaugeAanleverstatusViewModel Gauge { get; set; }


    // Aanleveringen lijst
    public List<WidgetAanleveringenListItemViewModel> Aanleveringen { get; set; } = new();


    // Rapportages lijst
    public RapportageDashboardWidgetViewModel Rapportages { get; set; }

}

public class WidgetAanleveringenListItemViewModel
{
    public Guid AanleveringId { get; set; }
    public string Referentie { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public DateTime Aanleverdatum { get; set; }
}

public class GaugeAanleverstatusViewModel
{
    public int Totaal { get; set; }
    public int Aangemaakt { get; set; }
    public int InBehandeling { get; set; }
    public int Ingediend { get; set; }
    public int Verwerkt { get; set; }
    public int Afgekeurd { get; set; }
}
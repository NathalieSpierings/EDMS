using System;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

public class MachtigingRegistratiesListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid ActiviteitId { get; set; }
    public DateTime Behandeldatum { get; set; }
    public DateTime AangemaaktOp { get; set; }

    public int Hoeveelheid { get; set; }
    public bool Verwerkt { get; set; }

    // Activiteit
    public ZorgproductEenheid Eenheid { get; set; }
    public string Zorgproduct { get; set; }
}
using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

public class MachtigingFacturenListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Naam { get; set; }
    public string FactuurNummer { get; set; }
    public string Periode { get; set; }
    public DateTime AangemaaktOp { get; set; }
}
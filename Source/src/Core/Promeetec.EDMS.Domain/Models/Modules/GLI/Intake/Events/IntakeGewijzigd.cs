using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Events;

public class IntakeGewijzigd : EventBase
{
    public string IntakeDatum { get; set; }
    public string? Opmerking { get; set; }
    public string? Lengte { get; set; }
    public string? Gewicht { get; set; }
    public string? Opnamedatum { get; set; }
}
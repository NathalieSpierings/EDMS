using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Events;

public class IntakeGewijzigd : EventBase
{
    public string IntakeDatum { get; set; }
    public string? Opmerking { get; set; }
    public string? Lengte { get; set; }
    public string? Gewicht { get; set; }
    public string? Opnamedatum { get; set; }
}
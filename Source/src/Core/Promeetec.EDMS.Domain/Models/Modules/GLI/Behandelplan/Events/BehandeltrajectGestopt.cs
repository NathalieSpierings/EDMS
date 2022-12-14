using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Events;

public class BehandeltrajectGestopt : EventBase
{
    public string VoortijdigGestopt { get; set; }
    public string VoortijdigeStopdatum { get; set; }
    public string VoortijdigeStopCode { get; set; }
    public string VoortijdigeStopReden { get; set; }
    public string Programma { get; set; }
    public string Fase { get; set; }
    public string Opmerking { get; set; }
}
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Events;

public class BehandeltrajectGestart : EventBase
{
    public string Startdatum { get; set; }
    public string? Einddatum { get; set; }
    public string GliProgramma { get; set; }
    public string Fase { get; set; }
    public string Opmerking { get; set; }
}
using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Events;

public class BehandeltrajectGestart : EventBase
{
    public string Startdatum { get; set; }
    public string? Einddatum { get; set; }
    public string GliProgramma { get; set; }
    public string Fase { get; set; }
    public string Opmerking { get; set; }
}
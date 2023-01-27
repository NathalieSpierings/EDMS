using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;

public class StopBehandelplan : CommandBase
{
    public GliStatus Status { get; set; }
    public GliProgramma Programma { get; set; }
    public GliBehandelfase Fase { get; set; }
    public DateTime VoortijdigeStopdatum { get; set; }
    public Guid RedenEindeZorgId { get; set; }
    public string VoortijdigeStopCode { get; set; }
    public string VoortijdigeStopReden { get; set; }
}
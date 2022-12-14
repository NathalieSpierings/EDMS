using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;

public class StopBehandeltraject : CommandBase
{
    public DateTime VoortijdigeStopdatum { get; set; }
    public string VoortijdigeStopCode { get; set; }
    public string VoortijdigeStopReden { get; set; }
    public string Opmerking { get; set; }
    public Guid RedenEindeZorgId { get; set; }

}
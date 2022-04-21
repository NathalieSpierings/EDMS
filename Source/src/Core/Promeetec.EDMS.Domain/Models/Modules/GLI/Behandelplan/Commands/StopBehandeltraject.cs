namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands
{
    public class StopBehandeltraject : DomainCommand<GliBehandelplan>
    {
        public DateTime VoortijdigeStopdatum { get; set; }
        public Guid RedenEindeZorgId { get; set; }
        public string VoortijdigeStopCode { get; set; }
        public string VoortijdigeStopReden { get; set; }
        public string Opmerking { get; set; }
    }
}
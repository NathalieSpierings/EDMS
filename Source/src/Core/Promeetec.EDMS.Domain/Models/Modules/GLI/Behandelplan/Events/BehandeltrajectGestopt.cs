namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Events
{
    public class BehandeltrajectGestopt : DomainEvent
    {
        public string VoortijdigGestopt { get; set; }
        public string VoortijdigeStopdatum { get; set; }
        public string VoortijdigeStopCode { get; set; }
        public string VoortijdigeStopReden { get; set; }
        public string Programma { get; set; }
        public string Fase { get; set; }
        public string Opmerking { get; set; }
    }
}
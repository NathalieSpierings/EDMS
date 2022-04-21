namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Events
{
    public class BehandeltrajectGestart : DomainEvent
    {
        public string Startdatum { get; set; }
        public string Einddatum { get; set; }
        public string GliProgramma { get; set; }
        public string Fase { get; set; }
        public string Opmerking { get; set; }
    }
}
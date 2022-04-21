namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Events
{
    public class IntakeGewijzigd : DomainEvent
    {
        public string IntakeDatum { get; set; }
        public string Opmerking { get; set; }
        public string Lengte { get; set; }
        public string Gewicht { get; set; }
        public string Opnamedatum { get; set; }
    }
}
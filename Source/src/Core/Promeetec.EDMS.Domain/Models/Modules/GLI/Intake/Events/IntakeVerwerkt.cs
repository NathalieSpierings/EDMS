namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Events
{
    public class IntakeVerwerkt : DomainEvent
    {
        public string Verwerkt { get; set; }
        public string VerwerktOp { get; set; }
    }
}
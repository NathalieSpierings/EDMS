namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Events
{
    public class IntakeStatusGewijzigd : DomainEvent
    {
        public string Status { get; set; }
    }
}
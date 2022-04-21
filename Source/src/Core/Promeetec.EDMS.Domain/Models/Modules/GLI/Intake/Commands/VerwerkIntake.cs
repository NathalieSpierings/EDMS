namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands
{
    public class VerwerkIntake : DomainCommand<GliIntake>
    {
        public DateTime VerwerktOp { get; set; }
    }
}
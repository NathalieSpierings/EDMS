namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands
{
    public class WijzigIntakeStatus : DomainCommand<GliIntake>
    {
        public GliStatus GliStatus { get; set; }
    }
}
using Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands
{
    public class WijzigIntake : DomainCommand<GliIntake>
    {
        public DateTime IntakeDatum { get; set; }
        public string Opmerking { get; set; }
        public NieuwWeegMoment WeegMoment { get; set; }
        public Guid BehandelaarId { get; set; }
    }
}
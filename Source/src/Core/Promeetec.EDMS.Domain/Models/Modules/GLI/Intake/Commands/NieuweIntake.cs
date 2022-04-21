using Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands
{
    public class NieuweIntake : DomainCommand<GliIntake>
    {
        public DateTime IntakeDatum { get; set; }
        public string Opmerking { get; set; }

        public NieuwWeegMoment WeegMoment { get; set; }

        public Guid VerzekerdeId { get; set; }
        public Guid BehandelaarId { get; set; }
        public Guid OrganisatieId { get; set; }
    }
}
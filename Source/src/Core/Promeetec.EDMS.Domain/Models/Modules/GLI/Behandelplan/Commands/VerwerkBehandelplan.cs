namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands
{
    public class VerwerkBehandelplan : DomainCommand<GliBehandelplan>
    {
        public DateTime VerwerktOp { get; set; }
        public GliStatus Status { get; set; }
    }
}
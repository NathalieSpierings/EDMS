namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands
{
    public class WijzigBehandelplanStatus : DomainCommand<GliBehandelplan>
    {
        public GliStatus Status { get; set; }
    }
}
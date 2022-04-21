namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands
{
    public class DeleteAanlevering : DomainCommand<Aanlevering>
    {
        public Shared.Status Status { get; set; }
    }
}

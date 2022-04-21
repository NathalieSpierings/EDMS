namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands
{
    public class ChangeEigenaarAanlevering : DomainCommand<Aanlevering>
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
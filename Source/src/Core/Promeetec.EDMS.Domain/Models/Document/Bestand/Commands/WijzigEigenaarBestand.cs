namespace Promeetec.EDMS.Domain.Document.Bestand.Commands
{
    public class WijzigEigenaarBestand : DomainCommand<Bestand>
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}
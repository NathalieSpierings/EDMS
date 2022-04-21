namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands
{
    public class ToewijzenVerzekerde : DomainCommand<Verzekerde>
    {
        public bool Shared { get; set; }
        public Guid VerzekerdeId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
    }
}
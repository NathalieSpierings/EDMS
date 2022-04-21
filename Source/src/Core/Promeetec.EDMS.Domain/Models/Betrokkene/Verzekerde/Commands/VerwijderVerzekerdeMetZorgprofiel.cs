namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands
{
    public class VerwijderVerzekerdeMetZorgprofiel : DomainCommand<Verzekerde>
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielEinddatum { get; set; }
    }
}
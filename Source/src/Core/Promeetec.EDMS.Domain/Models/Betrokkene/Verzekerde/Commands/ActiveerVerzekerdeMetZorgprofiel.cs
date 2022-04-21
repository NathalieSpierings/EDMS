namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands
{
    public class ActiveerVerzekerdeMetZorgprofiel : DomainCommand<Verzekerde>
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielStartdatum { get; set; }
    }
}
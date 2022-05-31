using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class SuspendVerzekerdeMetZorgprofiel : CommandBase
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielEinddatum { get; set; }
    }
}
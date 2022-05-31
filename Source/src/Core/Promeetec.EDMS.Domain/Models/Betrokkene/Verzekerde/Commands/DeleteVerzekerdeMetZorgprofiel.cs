using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class DeleteVerzekerdeMetZorgprofiel : CommandBase
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielEinddatum { get; set; }
    }
}
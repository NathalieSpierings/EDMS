using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class ReinstateVerzekerdeMetZorgprofiel : CommandBase
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielStartdatum { get; set; }
    }
}
using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class ReinstateVerzekerdeMetZorgprofiel : CommandBase
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielStartdatum { get; set; }
    }
}
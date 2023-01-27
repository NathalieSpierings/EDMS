using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class DeleteVerzekerdeMetZorgprofiel : CommandBase
    {
        public Guid VerzekerdeId { get; set; }
        public DateTime ProfielEinddatum { get; set; }
    }
}
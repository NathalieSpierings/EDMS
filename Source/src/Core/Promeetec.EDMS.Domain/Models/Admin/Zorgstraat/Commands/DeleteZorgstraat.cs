using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;

public class DeleteZorgstraat : CommandBase
{
    public Guid VerwijderdDoor { get; set; }
    public DateTime VerwijderdOp { get; set; }
}
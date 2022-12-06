using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;

public class DeleteZorgstraat : CommandBase
{
    public Guid VerwijderdDoor { get; set; }
    public DateTime VerwijderdOp { get; set; }
}
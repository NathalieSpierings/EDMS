namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

public class DeleteZorgstraat : DomainCommand<Zorgstraat>
{
    public Guid VerwijderdDoor { get; set; }
    public DateTime VerwijderdOp { get; set; }
}
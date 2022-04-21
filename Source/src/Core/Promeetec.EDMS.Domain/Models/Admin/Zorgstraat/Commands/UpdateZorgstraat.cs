namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

public class UpdateZorgstraat : DomainCommand<Zorgstraat>
{
    public string Naam { get; set; }
    public Shared.Status Status { get; set; }
}
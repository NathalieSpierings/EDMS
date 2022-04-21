namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

public class CreateZorgstraat : DomainCommand<Zorgstraat>
{
    public string Naam { get; set; }
}
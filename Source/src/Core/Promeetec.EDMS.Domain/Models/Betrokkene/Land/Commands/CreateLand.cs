namespace Promeetec.EDMS.Domain.Betrokkene.Land.Commands;

public class CreateLand : DomainCommand<Land>
{
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
}
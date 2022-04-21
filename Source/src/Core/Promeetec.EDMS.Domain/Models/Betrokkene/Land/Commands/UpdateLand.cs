using Promeetec.EDMS.Domain.Shared;

namespace Promeetec.EDMS.Domain.Betrokkene.Land.Commands;

public class UpdateLand : DomainCommand<Land>
{
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
    public Status Status { get; set; }
}
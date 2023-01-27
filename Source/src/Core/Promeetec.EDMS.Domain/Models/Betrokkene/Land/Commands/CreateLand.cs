using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Commands;

public class CreateLand : CommandBase
{
    public string CultureCode { get; set; }
    public string? NativeName { get; set; }
}
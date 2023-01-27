using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Commands;

public class UpdateLand : CommandBase
{
    public string CultureCode { get; set; }
    public string? NativeName { get; set; }
    public Status Status { get; set; }
}
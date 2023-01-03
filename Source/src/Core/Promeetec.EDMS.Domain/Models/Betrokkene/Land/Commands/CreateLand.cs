using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;

public class CreateLand : CommandBase
{
    public string CultureCode { get; set; }
    public string? NativeName { get; set; }
}